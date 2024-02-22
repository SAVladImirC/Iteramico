import 'package:flutter/material.dart';
import 'package:frontend/models/reminder.dart';
import 'package:frontend/screens/reminder/reminder.dart';

class ReminderList extends StatefulWidget {
  final List<Reminder> reminders;

  const ReminderList({super.key, required this.reminders});

  @override
  State<StatefulWidget> createState() => _ReminderListState();
}

class _ReminderListState extends State<ReminderList> {
  late final List<Reminder> _reminders;

  @override
  void initState() {
    super.initState();
    _reminders = widget.reminders;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildReminderList(),
    );
  }

  Widget _buildReminderList() {
    if (_reminders == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_reminders.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No reminders available. You can always add one!'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Reminders',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _reminders.length,
              itemBuilder: (context, index) {
                return ReminderWidget(reminder: _reminders[index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
