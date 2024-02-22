import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/screens/user/add_travel_buddy_dialog.dart';
import 'package:frontend/screens/user/user.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class TravelBuddiesList extends StatefulWidget {
  const TravelBuddiesList({super.key});

  @override
  State<StatefulWidget> createState() => _TravelBuddiesListState();
}

class _TravelBuddiesListState extends State<TravelBuddiesList> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();

  List<User>? _travelBuddies;

  @override
  void initState() {
    super.initState();
    _fetchTravelBuddies();
  }

  Future<void> _fetchTravelBuddies() async {
    var response = await _userService.getAllTravelBuddies();
    setState(() {
      _travelBuddies = response.data;
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
              return const UsersList();
            },
          ).then((value) => _fetchTravelBuddies());
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildEventList() {
    if (_travelBuddies == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_travelBuddies!.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No travel buddies available. You can always add one!'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Travel Buddies',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _travelBuddies!.length,
              itemBuilder: (context, index) {
                return UserWidget(
                  user: _travelBuddies![index],
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
