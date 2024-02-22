import 'package:flutter/material.dart';
import 'package:frontend/requests/event_create_request.dart';
import 'package:frontend/services/di_registration.dart';
import 'package:frontend/services/implementations/event_service_impl.dart';
import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';

class AddEventDialog extends StatefulWidget {
  @override
  _AddEventDialogState createState() => _AddEventDialogState();
}

class _AddEventDialogState extends State<AddEventDialog> {
  UserServiceImpl _userService = getIt<UserServiceImpl>();
  JourneyServiceImpl _journeyService = getIt<JourneyServiceImpl>();
  EventServiceImpl _eventService = getIt<EventServiceImpl>();

  late TextEditingController _nameController;
  late DateTime _fromDateTime;
  late DateTime _toDateTime;

  @override
  void initState() {
    super.initState();
    _nameController = TextEditingController();
    _fromDateTime = DateTime.now();
    _toDateTime = DateTime.now().add(Duration(hours: 1));
  }

  @override
  void dispose() {
    _nameController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Add Event'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _nameController,
              decoration: const InputDecoration(labelText: 'Event Name'),
            ),
            const SizedBox(height: 16),
            Row(
              children: [
                Expanded(
                  child: ListTile(
                    title: const Text('From:'),
                    subtitle: Text(
                      '${_fromDateTime.day}/${_fromDateTime.month}/${_fromDateTime.year} ${_fromDateTime.hour}:${_fromDateTime.minute}',
                    ),
                    onTap: () => _selectDateTime(true),
                  ),
                ),
                Expanded(
                  child: ListTile(
                    title: const Text('To:'),
                    subtitle: Text(
                      '${_toDateTime.day}/${_toDateTime.month}/${_toDateTime.year} ${_toDateTime.hour}:${_toDateTime.minute}',
                    ),
                    onTap: () => _selectDateTime(false),
                  ),
                ),
              ],
            ),
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
            EventCreateRequest request = EventCreateRequest(
                name: _nameController.text,
                creatorId: _userService.currentUser.id,
                journeyId: _journeyService.currentJourney.id,
                from: _fromDateTime,
                to: _toDateTime);
            var response = await _eventService.create(request);
            if (response.errorCode == null)
              // ignore: curly_braces_in_flow_control_structures, use_build_context_synchronously
              Navigator.of(context).pop();
          },
          child: const Text('Save'),
        ),
      ],
    );
  }

  Future<void> _selectDateTime(bool isFrom) async {
    final selectedDateTime = await showDatePicker(
      context: context,
      initialDate: isFrom ? _fromDateTime : _toDateTime,
      firstDate: DateTime(2000),
      lastDate: DateTime(2100),
      barrierColor: Colors.transparent,
    );
    if (selectedDateTime != null) {
      // ignore: use_build_context_synchronously
      final selectedTime = await showTimePicker(
        context: context,
        initialTime: TimeOfDay.now(),
      );
      if (selectedTime != null) {
        setState(() {
          if (isFrom) {
            _fromDateTime = DateTime(
              selectedDateTime.year,
              selectedDateTime.month,
              selectedDateTime.day,
              selectedTime.hour,
              selectedTime.minute,
            );
          } else {
            _toDateTime = DateTime(
              selectedDateTime.year,
              selectedDateTime.month,
              selectedDateTime.day,
              selectedTime.hour,
              selectedTime.minute,
            );
          }
        });
      }
    }
  }
}
