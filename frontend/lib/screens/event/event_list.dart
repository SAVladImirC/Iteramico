import 'package:flutter/material.dart';
import 'package:frontend/models/event.dart';
import 'package:frontend/screens/event/event.dart';

class EventList extends StatefulWidget {
  final List<Event> events;

  const EventList({super.key, required this.events});

  @override
  State<StatefulWidget> createState() => _EventListState();
}

class _EventListState extends State<EventList> {
  late final List<Event> _events;

  @override
  void initState() {
    super.initState();
    _events = widget.events;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildEventList(),
    );
  }

  Widget _buildEventList() {
    if (_events == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_events.isEmpty) {
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
              itemCount: _events.length,
              itemBuilder: (context, index) {
                return EventWidget(event: _events[index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
