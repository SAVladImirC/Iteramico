import 'package:flutter/material.dart';
import 'package:frontend/models/expense.dart';
import 'package:frontend/screens/expense/expense.dart';

class ExpenseList extends StatefulWidget {
  final List<Expense> expenses;

  const ExpenseList({super.key, required this.expenses});

  @override
  State<StatefulWidget> createState() => _ExpenseListState();
}

class _ExpenseListState extends State<ExpenseList> {
  late final List<Expense> _expenses;

  @override
  void initState() {
    super.initState();
    _expenses = widget.expenses;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildexpenseList(),
    );
  }

  Widget _buildexpenseList() {
    if (_expenses == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_expenses.isEmpty) {
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
              itemCount: _expenses.length,
              itemBuilder: (context, index) {
                return ExpenseWidget(expense: _expenses[index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
