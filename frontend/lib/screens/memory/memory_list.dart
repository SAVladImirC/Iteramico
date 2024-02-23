import 'package:flutter/material.dart';
import 'package:frontend/models/memory.dart';
import 'package:frontend/screens/memory/camera.dart';
import 'package:frontend/screens/memory/memory.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/memory_service_impl.dart';

class MemoryList extends StatefulWidget {
  const MemoryList({super.key});

  @override
  State<StatefulWidget> createState() => _MemoryListState();
}

class _MemoryListState extends State<MemoryList> {
  MemoryServiceImpl _memoryService = getIt<MemoryServiceImpl>();
  JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();

  List<Memory>? _memories;

  @override
  void initState() {
    super.initState();
    _fetchMemories();
  }

  Future<void> _fetchMemories() async {
    var response = await _memoryService
        .getAllMemoriesForJourney(_journeyService.currentJourney.id);
    setState(() {
      _memories = response.data;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildmemoryList(),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => const CameraScreen(),
            ),
          );
        },
        child: const Icon(Icons.add),
      ),
    );
  }

  Widget _buildmemoryList() {
    if (_memories == null) {
      // Show loading indicator while fetching journeys
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (_memories!.isEmpty) {
      // Show message if no journeys available
      return const Center(
        child: Text('No memories available. You can always add one!'),
      );
    } else {
      // Build list view of journeys
      return Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: 16.0),
            child: Text(
              'Memories',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _memories!.length,
              itemBuilder: (context, index) {
                return MemoryWidget(memory: _memories![index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
