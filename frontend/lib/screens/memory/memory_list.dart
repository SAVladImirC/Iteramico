import 'package:flutter/material.dart';
import 'package:frontend/models/memory.dart';
import 'package:frontend/screens/memory/add_image_dialog.dart';
import 'package:frontend/screens/memory/camera.dart';

class MemoryList extends StatefulWidget {
  final List<Memory> memories;

  const MemoryList({super.key, required this.memories});

  @override
  State<StatefulWidget> createState() => _MemoryListState();
}

class _MemoryListState extends State<MemoryList> {
  late final List<Memory> _memories;

  @override
  void initState() {
    super.initState();
    _memories = widget.memories;
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
              builder: (context) => CameraScreen(),
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
    } else if (_memories.isEmpty) {
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
              'memories',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _memories.length,
              itemBuilder: (context, index) {
                //return memoryWidget(memory: _memories[index]);
              },
            ),
          ),
        ],
      );
    }
  }
}
