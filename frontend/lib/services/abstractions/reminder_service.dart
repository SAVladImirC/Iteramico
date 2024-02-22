import 'package:frontend/models/reminder.dart';
import 'package:frontend/requests/reminder_create_request.dart';
import 'package:frontend/response/response.dart';

abstract class ReminderService {
  Future<Response<List<Reminder>>> getAllRemindersForJourney(int journeyId);
  Future<Response<Reminder>> create(ReminderCreateRequest request);
}
