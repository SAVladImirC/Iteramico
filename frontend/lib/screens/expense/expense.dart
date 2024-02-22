import 'package:flutter/material.dart';
import 'package:frontend/models/expense.dart';

class ExpenseWidget extends StatefulWidget {
  final Expense expense;

  const ExpenseWidget({super.key, required this.expense});

  @override
  State<StatefulWidget> createState() => _ExpenseWidgetState();
}

class _ExpenseWidgetState extends State<ExpenseWidget> {
  late final Expense _expense;

  @override
  void initState() {
    super.initState();
    _expense = widget.expense;
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 3,
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      child: ListTile(
        title: Text(
          _expense.description,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 16.0,
          ),
        ),
        subtitle: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Creator: ${_expense.creator.auth.username}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Text(
              'Price: ${_expense.price}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Text(
              'Currency: ${_expense.currency}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            )
          ],
        ),
      ),
    );
  }
}
