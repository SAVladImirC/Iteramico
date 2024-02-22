import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:frontend/requests/memory_create_request.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/memory_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class AddImageDialog extends StatefulWidget {
  final File imageFile;

  const AddImageDialog({Key? key, required this.imageFile}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _AddImageDialogState createState() => _AddImageDialogState();
}

class _AddImageDialogState extends State<AddImageDialog> {
  final MemoryServiceImpl _memoryService = getIt<MemoryServiceImpl>();
  final JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();
  final UserServiceImpl _userServiceImpl = getIt<UserServiceImpl>();

  late TextEditingController _nameController;

  @override
  void initState() {
    super.initState();
    _nameController = TextEditingController();
  }

  @override
  void dispose() {
    _nameController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Add Image'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _nameController,
              decoration: const InputDecoration(labelText: 'Image Name'),
            ),
            const SizedBox(height: 16),
            Image.file(widget.imageFile),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text('Cancel'),
        ),
        ElevatedButton(
          onPressed: () async {
            final name = _nameController.text;
            List<int> imageBytes = await widget.imageFile.readAsBytes();
            MemoryCreateRequest request = MemoryCreateRequest(
                base64image: base64Encode(imageBytes),
                name: name,
                creatorId: _userServiceImpl.currentUser.id,
                journeyId: _journeyService.currentJourney.id);

            await _memoryService.create(request);

            // ignore: use_build_context_synchronously
            Navigator.of(context).pop();
          },
          child: const Text('Save'),
        ),
      ],
    );
  }
}
