import 'package:flutter/material.dart';
import 'package:frontend/models/journey.dart';
import 'package:frontend/screens/event/event_list.dart';
import 'package:frontend/screens/expense/expense_list.dart';
import 'package:frontend/screens/journey/journey_participants_list.dart';
import 'package:frontend/screens/memory/memory_list.dart';
import 'package:frontend/screens/reminder/reminder_list.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';

class JourneyDetails extends StatefulWidget {
  final int journeyId;

  const JourneyDetails({super.key, required this.journeyId});

  @override
  State<StatefulWidget> createState() => _JourneyDetailsState();
}

class _JourneyDetailsState extends State<JourneyDetails> {
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  late final int _journeyId;
  Journey? _journey;

  int _currentIndex = 0;

  List<Widget> destinations = [
    const NavigationDestination(
      selectedIcon: Icon(Icons.photo),
      icon: Icon(Icons.photo_outlined),
      label: 'Photos',
    ),
    const NavigationDestination(
      selectedIcon: Icon(Icons.punch_clock),
      icon: Icon(Icons.punch_clock_outlined),
      label: 'Reminders',
    ),
    const NavigationDestination(
      selectedIcon: Icon(Icons.event),
      icon: Icon(Icons.event_outlined),
      label: 'Events',
    ),
    const NavigationDestination(
      selectedIcon: Icon(Icons.monetization_on),
      icon: Icon(Icons.monetization_on_outlined),
      label: 'Expenses',
    ),
    const NavigationDestination(
      selectedIcon: Icon(Icons.people),
      icon: Icon(Icons.people_outline),
      label: 'Participants',
    )
  ];

  late List<Widget> screens = [];

  @override
  void initState() {
    super.initState();
    _journeyId = widget.journeyId;
    _loadJourney();
  }

  void _loadJourney() async {
    var response = await _journeyService.getJourneyById(_journeyId);
    setState(() {
      _journey = response.data!;
      _journeyService.currentJourney = _journey!;
      screens = [
        MemoryList(memories: []),
        ReminderList(reminders: _journey?.reminders ?? []),
        EventList(events: _journey?.events ?? []),
        ExpenseList(expenses: _journey?.expenses ?? []),
        JourneyParticipantsList()
      ];
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(_journey?.name ?? ''),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        actions: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16.0),
            child: Image.asset(
              'assets/logo.png',
              width: 60,
              height: 60,
            ),
          ),
        ],
      ),
      bottomNavigationBar: NavigationBar(
        onDestinationSelected: (int index) {
          setState(() {
            _currentIndex = index;
          });
        },
        indicatorColor: Colors.red,
        selectedIndex: _currentIndex,
        destinations: destinations,
      ),
      body: screens.isEmpty
          ? const CircularProgressIndicator()
          : screens[_currentIndex],
    );
  }
}
