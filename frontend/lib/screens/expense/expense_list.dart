import 'package:flutter/material.dart';
import 'package:frontend/models/expense.dart';
import 'package:frontend/screens/expense/add_expense_dialog.dart';
import 'package:frontend/screens/expense/expense.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/expense_service_impl.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';

class ExpenseList extends StatefulWidget {
  const ExpenseList({super.key});

  @override
  State<StatefulWidget> createState() => _ExpenseListState();
}

class _ExpenseListState extends State<ExpenseList> {
  final ExpenseServiceImpl _expenseService = getIt<ExpenseServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  List<Expense>? _expenses;

  @override
  void initState() {
    super.initState();
    _loadExpenses();
  }

  Future<void> _loadExpenses() async {
    var response = await _expenseService
        .getAllExpensesForJourney(_journeyService.currentJourney.id);

    setState(() {
      _expenses = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildexpenseList(),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          showDialog(
            context: context,
            builder: (BuildContext context) {
              return const AddExpenseDialog();
            },
          ).then((value) => _loadExpenses());
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildexpenseList() {
    if (_expenses == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_expenses!.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No expenses available. You can always add one!'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Expenses',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _expenses!.length,
              itemBuilder: (context, index) {
                return ExpenseWidget(expense: _expenses![index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
