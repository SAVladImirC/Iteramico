import 'package:frontend/services/implementations/journey_service_impl.dart';
import 'package:frontend/services/implementations/user_service_impl.dart';
import 'package:get_it/get_it.dart';

final getIt = GetIt.instance;

void setup() {
  getIt.registerLazySingleton<UserServiceImpl>(() => UserServiceImpl());
  getIt.registerLazySingleton<JourneyServiceImpl>(() => JourneyServiceImpl());
}
