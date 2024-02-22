import 'package:frontend/models/event.dart';
import 'package:frontend/requests/event_create_request.dart';
import 'package:frontend/response/response.dart';

abstract class EventService {
  Future<Response<List<Event>>> getAllEventsForJourney(int journeyId);
  Future<Response<Event>> create(EventCreateRequest request);
}
