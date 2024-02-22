import 'package:frontend/models/journey.dart';
import 'package:frontend/models/journey_participation.dart';
import 'package:frontend/response/response.dart';

abstract class JourneyService {
  Future<Response<List<JourneyParticipation>>> getAllJourneysForUser(
      int userId);

  Future<Response<Journey>> getJourneyById(int id);

  Future<Response<bool>> addJourneyParticipation(int userId);
}
