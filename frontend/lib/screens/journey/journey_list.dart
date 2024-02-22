import 'package:flutter/material.dart';
import 'package:frontend/models/journey_participation.dart';
import 'package:frontend/screens/journey/journey.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart'; // Import your Journey class

class JourneyListScreen extends StatefulWidget {
  const JourneyListScreen({Key? key}) : super(key: key);

  @override
  _JourneyListScreenState createState() => _JourneyListScreenState();
}

class _JourneyListScreenState extends State<JourneyListScreen> {
  late List<JourneyParticipation> _journeyParticipations = [];

  @override
  void initState() {
    super.initState();
    _fetchJourneys();
  }

  Future<void> _fetchJourneys() async {
    UserServiceImpl _userService = getIt<UserServiceImpl>();
    JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

    var response = await _journeyService
        .getAllJourneysForUser(_userService.currentUser.id);

    setState(() {
      _journeyParticipations = response.data ?? [];
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildJourneyList(),
    );
  }

  Widget _buildJourneyList() {
    if (_journeyParticipations == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_journeyParticipations.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No journeys available'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'My Journeys',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _journeyParticipations.length,
              itemBuilder: (context, index) {
                return JourneyWidget(
                    journeyParticipation: _journeyParticipations[index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
