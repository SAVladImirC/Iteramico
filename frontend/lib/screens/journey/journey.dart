import 'package:flutter/material.dart';
import 'package:frontend/models/journey_participation.dart';

class JourneyWidget extends StatefulWidget {
  final JourneyParticipation journeyParticipation;

  const JourneyWidget({super.key, required this.journeyParticipation});

  @override
  State<StatefulWidget> createState() {
    return _JourneyState();
  }
}

class _JourneyState extends State<JourneyWidget> {
  late final JourneyParticipation _journeyParticipation;

  @override
  void initState() {
    super.initState();
    _journeyParticipation = widget.journeyParticipation;
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 3,
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      child: ListTile(
        title: Text(
          _journeyParticipation.journey.name,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 16.0,
          ),
        ),
        subtitle: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Creator: ${_journeyParticipation.journey.creator.auth.username}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Text(
              'To: ${_journeyParticipation.journey.to.name}, ${_journeyParticipation.journey.to.country.name}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Text(
              'Joined: ${_formatDate(_journeyParticipation.joinedOn)}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
          ],
        ),
        onTap: () {
          // Define the action when the ListTile is tapped
          // For example, navigate to a detailed view of the journey
        },
      ),
    );
  }

  String _formatDate(DateTime date) {
    return '${date.day}/${date.month}/${date.year}';
  }
}
