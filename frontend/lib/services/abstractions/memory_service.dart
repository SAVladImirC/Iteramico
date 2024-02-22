import 'package:frontend/models/memory.dart';
import 'package:frontend/requests/memory_create_request.dart';
import 'package:frontend/response/response.dart';

abstract class MemoryService {
  Future<Response<List<Memory>>> getAllMemoriesForJourney(int journeyId);
  Future<Response<Memory>> create(MemoryCreateRequest request);
}
