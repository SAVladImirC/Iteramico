import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/screens/journey/add_participant_dialog.dart';
import 'package:frontend/screens/user/user.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class JourneyParticipantsList extends StatefulWidget {
  const JourneyParticipantsList({super.key});

  @override
  State<StatefulWidget> createState() => _JourneyParticipantsListState();
}

class _JourneyParticipantsListState extends State<JourneyParticipantsList> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  List<User>? _journeyParticipants;

  @override
  void initState() {
    super.initState();
    _fetchTravelBuddies();
  }

  Future<void> _fetchTravelBuddies() async {
    var response = await _userService
        .getAllJourneyParticipants(_journeyService.currentJourney.id);
    setState(() {
      _journeyParticipants = response.data;
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
              return const AddParticipantDialog();
            },
          ).then((value) => _fetchTravelBuddies());
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildEventList() {
    if (_journeyParticipants == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_journeyParticipants!.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text(''),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Participants',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _journeyParticipants!.length,
              itemBuilder: (context, index) {
                return UserWidget(
                  user: _journeyParticipants![index],
                  showAddBuddy: false,
                  showAddParticipant: false,
                );
              },
            ),
          ),
        ],
      );
    }
  }
}
