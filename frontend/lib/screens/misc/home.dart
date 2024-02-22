import 'package:flutter/material.dart';
import 'package:frontend/screens/journey/journey_list.dart';
import 'package:frontend/screens/location.dart';
import 'package:frontend/screens/user/my_profile_screen.dart';
import 'package:frontend/screens/user/travel_buddies_screen.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<StatefulWidget> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _selectedIndex = 0;
  @override
  Widget build(BuildContext context) {
    List<Widget> _widgetOptions = <Widget>[
      JourneyListScreen(),
      TravelBuddiesList(),
      MyProfileScreen()
    ];

    void _onItemTapped(int index) {
      setState(() {
        _selectedIndex = index;
      });
    }

    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue,
        title: Padding(
          padding: const EdgeInsets.only(right: 75),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Image.asset(
                'assets/logo.png',
                height: 60,
              ),
              const Text(
                'Iteramico',
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.black,
                ),
              ),
            ],
          ),
        ),
        centerTitle: true,
      ),
      body: Center(child: _widgetOptions[_selectedIndex]),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            const DrawerHeader(
                decoration: BoxDecoration(
                  color: Colors.blue,
                ),
                child: Column(
                  children: [
                    LocationInfoWidget(),
                    Text(
                      'Menu',
                      style: TextStyle(
                        color: Colors.white,
                        fontSize: 24,
                      ),
                    ),
                  ],
                )),
            ListTile(
              leading: const Icon(Icons.airplanemode_active),
              enabled: true,
              title: const Text('My Journeys'),
              onTap: () {
                _onItemTapped(0);
                Navigator.pop(context); // Close the drawer
              },
            ),
            ListTile(
              leading: const Icon(Icons.group),
              title: const Text('My Travel Buddies'),
              enabled: true,
              onTap: () {
                _onItemTapped(1);
                Navigator.pop(context); // Close the drawer
              },
            ),
            ListTile(
              leading: const Icon(Icons.person),
              enabled: true,
              title: const Text('My Profile'),
              onTap: () {
                _onItemTapped(2);
                Navigator.pop(context); // Close the drawer
              },
            )
          ],
        ),
      ),
    );
  }
}
