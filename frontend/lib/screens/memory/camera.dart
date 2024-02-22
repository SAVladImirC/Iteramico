import 'dart:io';

import 'package:camera/camera.dart';
import 'package:flutter/material.dart';

import 'add_image_dialog.dart';

class CameraScreen extends StatefulWidget {
  const CameraScreen({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _CameraScreenState createState() => _CameraScreenState();
}

class _CameraScreenState extends State<CameraScreen> {
  late CameraController _controller;
  late Future<void> _initializeControllerFuture;
  late XFile _imageFile;
  late bool _isFrontCamera = false;

  @override
  void initState() {
    super.initState();
    _initializeControllerFuture = _initializeCamera();
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  Future<void> _initializeCamera() async {
    final cameras = await availableCameras();
    final camera = _isFrontCamera ? cameras.last : cameras.first;
    _controller = CameraController(camera, ResolutionPreset.medium);
    _initializeControllerFuture = _controller.initialize();
    await _initializeControllerFuture;
  }

  Future<void> _toggleCamera() async {
    setState(() {
      _isFrontCamera = !_isFrontCamera;
    });
    await _initializeCamera();
    await _initializeControllerFuture;
    setState(() {});
  }

  Future<void> _takePicture() async {
    try {
      final XFile imageFile = await _controller.takePicture();
      setState(() {
        _imageFile = imageFile;
      });
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AddImageDialog(imageFile: File(imageFile.path));
        },
      );
    } catch (e) {
      print('Error taking picture: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Camera'),
      ),
      body: FutureBuilder<void>(
        future: _initializeControllerFuture,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.done) {
            return CameraPreview(_controller);
          } else {
            return const Center(child: CircularProgressIndicator());
          }
        },
      ),
      floatingActionButton: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          FloatingActionButton(
            onPressed: _toggleCamera,
            child: const Icon(Icons.flip_camera_android),
          ),
          FloatingActionButton(
            onPressed: _takePicture,
            child: const Icon(Icons.camera),
          ),
        ],
      ),
    );
  }
}
