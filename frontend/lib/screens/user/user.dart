import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/services/abstractions/journey_service.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class UserWidget extends StatefulWidget {
  final User user;
  final bool showAddBuddy;
  final bool showAddParticipant;
  const UserWidget(
      {super.key,
      required this.user,
      required this.showAddBuddy,
      required this.showAddParticipant});

  @override
  State<StatefulWidget> createState() => _UserWidgetState();
}

class _UserWidgetState extends State<UserWidget> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  late final User _user;

  late bool _showAddBuddy;
  late bool _showAddParticipant;

  @override
  void initState() {
    super.initState();
    _user = widget.user;
    _showAddBuddy = widget.showAddBuddy;
    _showAddParticipant = widget.showAddParticipant;
  }

  @override
  Widget build(BuildContext context) {
    return Card(
        elevation: 3,
        margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
        child: Row(
          children: [
            Expanded(
              child: ListTile(
                title: Text(
                  _user.auth.username,
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 16.0,
                  ),
                ),
                subtitle: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Name: ${_user.firstName} ${_user.lastName}',
                      style: const TextStyle(
                        fontSize: 14.0,
                        color: Colors.grey,
                      ),
                    ),
                    Text(
                      'Gender: ${_user.gender}',
                      style: const TextStyle(
                        fontSize: 14.0,
                        color: Colors.grey,
                      ),
                    ),
                  ],
                ),
              ),
            ),
            if (_showAddBuddy)
              IconButton(
                icon: const Icon(Icons.add),
                onPressed: () async {
                  var result = await _userService.becomeTravelBuddy(_user.id);
                  if (result.data == true) {
                    setState(() {
                      _showAddBuddy = false;
                    });
                  }
                },
              ),
            if (_showAddParticipant)
              IconButton(
                icon: const Icon(Icons.add),
                onPressed: () async {
                  var result =
                      await _journeyService.addJourneyParticipation(_user.id);
                  if (result.data == true) {
                    setState(() {
                      _showAddParticipant = false;
                    });
                  }
                },
              ),
          ],
        ));
  }
}
