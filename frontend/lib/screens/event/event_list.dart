import 'package:flutter/material.dart';
import 'package:frontend/models/event.dart';
import 'package:frontend/screens/event/event.dart';
import 'package:frontend/screens/event/event_create_dialog.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/event_service_impl.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';

class EventList extends StatefulWidget {
  const EventList({super.key});

  @override
  State<StatefulWidget> createState() => _EventListState();
}

class _EventListState extends State<EventList> {
  EventServiceImpl _eventService = getIt<EventServiceImpl>();
  JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  List<Event>? _events;

  @override
  void initState() {
    super.initState();
    _fetchEvents();
  }

  Future<void> _fetchEvents() async {
    var response = await _eventService
        .getAllEventsForJourney(_journeyService.currentJourney.id);
    setState(() {
      _events = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildEventList(),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          showDialog(
            context: context,
            builder: (BuildContext context) {
              return AddEventDialog();
            },
          ).then((value) => _fetchEvents());
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildEventList() {
    if (_events == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_events!.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No events available. You can always add one!'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Events',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _events!.length,
              itemBuilder: (context, index) {
                return EventWidget(event: _events![index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
