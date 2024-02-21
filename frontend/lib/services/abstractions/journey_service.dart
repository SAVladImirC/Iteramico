import 'package:frontend/models/journey_participation.dart';
import 'package:frontend/response/response.dart';

abstract class JourneyService {
  Future<Response<List<JourneyParticipation>>> getAllJourneysForUser(
      int userId);
}
