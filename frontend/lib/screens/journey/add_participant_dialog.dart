import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/screens/user/user.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class AddParticipantDialog extends StatefulWidget {
  const AddParticipantDialog({super.key});

  @override
  State<StatefulWidget> createState() => _AddParticipantDialogState();
}

class _AddParticipantDialogState extends State<AddParticipantDialog> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  List<User>? _users;

  @override
  void initState() {
    super.initState();
    _fetchTravelBuddies();
  }

  Future<void> _fetchTravelBuddies() async {
    var response = await _userService.getAllTravelBuddies();
    setState(() {
      _users = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: _buildTravelBuddyList(),
    );
  }

  Widget _buildTravelBuddyList() {
    if (_users == null) {
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_users!.isEmpty) {
      return const Center(
        child: Text(''),
      );
    } else {
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
              itemCount: _users!.length,
              itemBuilder: (context, index) {
                return UserWidget(
                  user: _users![index],
                  showAddBuddy: false,
                  showAddParticipant: true,
                );
              },
            ),
          ),
        ],
      );
    }
  }
}
