import 'package:flutter/material.dart';
import 'package:frontend/models/user.dart';
import 'package:frontend/screens/user/user.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class UsersList extends StatefulWidget {
  const UsersList({super.key});

  @override
  State<StatefulWidget> createState() => _UsersListState();
}

class _UsersListState extends State<UsersList> {
  final UserServiceImpl _userService = getIt<UserServiceImpl>();
  String _keyword = "";
  final TextEditingController _searchController = TextEditingController();
  List<User>? _users;

  @override
  void initState() {
    super.initState();
    _fetchUsers();
  }

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  Future<void> _fetchUsers() async {
    var response = await _userService.search(_keyword);
    setState(() {
      _users = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: TextField(
          controller: _searchController,
          decoration: const InputDecoration(
            hintText: 'Search...',
          ),
          onChanged: (value) {
            setState(() {
              _keyword = value;
            });
            _fetchUsers();
          },
        ),
      ),
      body: _buildEventList(),
    );
  }

  Widget _buildEventList() {
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
                  showAddBuddy: true,
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
