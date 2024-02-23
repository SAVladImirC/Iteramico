import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/requests/create_expense_request.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/expense_service_impl.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class AddExpenseDialog extends StatefulWidget {
  const AddExpenseDialog({Key? key}) : super(key: key);

  @override
  _AddExpenseDialogState createState() => _AddExpenseDialogState();
}

class _AddExpenseDialogState extends State<AddExpenseDialog> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();
  final ExpenseServiceImpl _expenseService = getIt<ExpenseServiceImpl>();

  late TextEditingController _priceController;
  late TextEditingController _currencyController;
  late TextEditingController _descriptionController;
  List<User> _selectedParticipants = [];
  List<User>? _allParticipants = [];

  @override
  void initState() {
    super.initState();
    _priceController = TextEditingController();
    _currencyController = TextEditingController();
    _descriptionController = TextEditingController();
    _fetchTravelParticipants();
  }

  Future<void> _fetchTravelParticipants() async {
    var response = await _userService
        .getAllJourneyParticipants(_journeyService.currentJourney.id);
    setState(() {
      _allParticipants = response.data;
    });
  }

  @override
  void dispose() {
    _priceController.dispose();
    _currencyController.dispose();
    _descriptionController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Add Expense'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _priceController,
              decoration: const InputDecoration(labelText: 'Price'),
              keyboardType: TextInputType.number,
            ),
            TextField(
              controller: _currencyController,
              decoration: const InputDecoration(labelText: 'Currency'),
            ),
            TextField(
              controller: _descriptionController,
              decoration: const InputDecoration(labelText: 'Description'),
            ),
            const SizedBox(height: 16),
            const Text('Participants:'),
            Column(
              children: _allParticipants!.map((user) {
                return CheckboxListTile(
                  title: Text(user.auth.username),
                  value: _selectedParticipants.contains(user),
                  onChanged: (bool? value) {
                    setState(() {
                      if (value != null && value) {
                        _selectedParticipants.add(user);
                      } else {
                        _selectedParticipants.remove(user);
                      }
                    });
                  },
                );
              }).toList(),
            ),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text('Cancel'),
        ),
        ElevatedButton(
          onPressed: () async {
            ExpenseCreateRequest request = ExpenseCreateRequest(
                price: double.tryParse(_priceController.text) ?? 0.0,
                currency: _currencyController.text,
                description: _descriptionController.text,
                creatorId: _userService.currentUser.id,
                journeyId: _journeyService.currentJourney.id,
                participants: _selectedParticipants.map((e) => e.id).toList());
            var response = await _expenseService.create(request);
            // ignore: use_build_context_synchronously
            if (response.errorCode == null) Navigator.of(context).pop();
          },
          child: const Text('Save'),
        ),
      ],
    );
  }
}
