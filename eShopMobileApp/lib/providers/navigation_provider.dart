import 'package:flutter_riverpod/flutter_riverpod.dart';

final navigationProvider =
    StateNotifierProvider<NavigationNotifier, int>((ref) {
  return NavigationNotifier();
});

class NavigationNotifier extends StateNotifier<int> {
  NavigationNotifier() : super(0);

  void updateIndex(int index) {
    state = index;
  }
}
