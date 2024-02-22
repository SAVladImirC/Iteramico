import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:frontend/models/memory.dart';

class MemoryWidget extends StatefulWidget {
  final Memory memory;

  const MemoryWidget({super.key, required this.memory});

  @override
  State<StatefulWidget> createState() => _MemoryWidgetState();
}

class _MemoryWidgetState extends State<MemoryWidget> {
  late final Memory _memory;

  @override
  void initState() {
    super.initState();
    _memory = widget.memory;
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 3,
      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
      child: ListTile(
        title: Text(
          _memory.name,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 16.0,
          ),
        ),
        subtitle: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Creator: ${_memory.creator.auth.username}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Text(
              'Posted on: ${_formatDate(_memory.postedOn)}',
              style: const TextStyle(
                fontSize: 14.0,
                color: Colors.grey,
              ),
            ),
            Container(
              width: double.infinity,
              height: 200, // Adjust height as needed
              child: Image.memory(
                base64Decode(_memory.imageBase64!), // Decode base64 string
                fit: BoxFit.contain, // Scale image to fit within the container
              ),
            )
          ],
        ),
      ),
    );
  }

  String _formatDate(DateTime date) {
    return '${date.day}/${date.month}/${date.year} ${date.hour}:${date.minute}';
  }
}
