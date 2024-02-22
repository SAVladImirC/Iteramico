import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/requests/reminder_create_request.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/reminder_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class AddReminderDialog extends StatefulWidget {
  @override
  _AddReminderDialogState createState() => _AddReminderDialogState();
}

class _AddReminderDialogState extends State<AddReminderDialog> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();
  final ReminderServiceImpl _reminderService = getIt<ReminderServiceImpl>();

  late int _selectedUser = 0;
  late TextEditingController _nameController;
  late DateTime _selectedDateTime = DateTime.now();

  List<User>? journeyParticipants;

  @override
  void initState() {
    super.initState();
    _nameController = TextEditingController();
    _fetchJourneyParticipants();
  }

  Future<void> _fetchJourneyParticipants() async {
    var response = await _userService
        .getAllJourneyParticipants(_journeyService.currentJourney.id);
    setState(() {
      journeyParticipants = response.data;
      _selectedUser = journeyParticipants![0].id;
    });
  }

  @override
  void dispose() {
    _nameController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Add Reminder'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _nameController,
              decoration: const InputDecoration(labelText: 'Note'),
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _selectDateTime(context);
              },
              child: ListTile(
                  title: const Text('Deadline: '),
                  subtitle: Text(
                    '${_selectedDateTime.day}/${_selectedDateTime.month}/${_selectedDateTime.year} ${_selectedDateTime.hour}:${_selectedDateTime.minute}',
                  ),
                  onTap: () => _selectDateTime(context)),
            ),
            const SizedBox(height: 16),
            DropdownButtonFormField<int>(
              value: _selectedUser,
              onChanged: (newValue) {
                setState(() {
                  _selectedUser = newValue!;
                });
              },
              items:
                  journeyParticipants?.map<DropdownMenuItem<int>>((User user) {
                return DropdownMenuItem<int>(
                  value: user.id,
                  child: Text(user.auth.username),
                );
              }).toList(),
              decoration: const InputDecoration(labelText: 'Username'),
            ),
          ],
        ),
      ),
      actions: <Widget>[
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text('Cancel'),
        ),
        ElevatedButton(
          onPressed: () async {
            ReminderCreateRequest request = ReminderCreateRequest(
                note: _nameController.text,
                deadline: _selectedDateTime,
                creatorId: _userService.currentUser.id,
                journeyId: _journeyService.currentJourney.id,
                forId: _selectedUser);
            var response = await _reminderService.create(request);
            // ignore: use_build_context_synchronously
            if (response.errorCode == null) Navigator.of(context).pop();
          },
          child: const Text('Save'),
        ),
      ],
    );
  }

  Future<void> _selectDateTime(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: _selectedDateTime,
      firstDate: DateTime.now(),
      lastDate: DateTime(2101),
    );
    if (picked != null && picked != _selectedDateTime)
      // ignore: curly_braces_in_flow_control_structures
      setState(() {
        _selectedDateTime = picked;
      });
  }
}
