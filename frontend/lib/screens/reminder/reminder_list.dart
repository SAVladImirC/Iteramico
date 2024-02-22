import 'package:flutter/material.dart';
import 'package:frontend/models/reminder.dart';
import 'package:frontend/screens/reminder/reminder.dart';
import 'package:frontend/screens/reminder/reminder_create_dialog.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/reminder_service_impl.dart';

class ReminderList extends StatefulWidget {
  final List<Reminder> reminders;

  const ReminderList({super.key, required this.reminders});

  @override
  State<StatefulWidget> createState() => _ReminderListState();
}

class _ReminderListState extends State<ReminderList> {
  ReminderServiceImpl _reminderService = getIt<ReminderServiceImpl>();
  JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  List<Reminder>? _reminders;

  @override
  void initState() {
    super.initState();
    _fetchReminders();
  }

  Future<void> _fetchReminders() async {
    var response = await _reminderService
        .getAllRemindersForJourney(_journeyService.currentJourney.id);
    setState(() {
      _reminders = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildReminderList(),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          showDialog(
            context: context,
            builder: (BuildContext context) {
              return AddReminderDialog();
            },
          ).then((value) => _fetchReminders());
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildReminderList() {
    if (_reminders == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_reminders!.isEmpty) {
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
              itemCount: _reminders!.length,
              itemBuilder: (context, index) {
                return ReminderWidget(reminder: _reminders![index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
