import 'dart:io';

import 'package:flutter/material.dart';

class AddImageDialog extends StatefulWidget {
  final File imageFile;

  const AddImageDialog({Key? key, required this.imageFile}) : super(key: key);

  @override
  _AddImageDialogState createState() => _AddImageDialogState();
}

class _AddImageDialogState extends State<AddImageDialog> {
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
      title: Text('Add Image'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _nameController,
              decoration: InputDecoration(labelText: 'Image Name'),
            ),
            SizedBox(height: 16),
            Image.file(widget.imageFile),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: Text('Cancel'),
        ),
        ElevatedButton(
          onPressed: () {
            final imageName = _nameController.text;
            // Implement logic to save the memory with the image and name
            Navigator.of(context).pop();
          },
          child: Text('Save'),
        ),
      ],
    );
  }
}
