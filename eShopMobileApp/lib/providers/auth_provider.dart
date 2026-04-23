import 'package:flutter_riverpod/flutter_riverpod.dart';

final authProvider = StateNotifierProvider<AuthNotifier, AuthState>((ref) {
  return AuthNotifier();
});

class AuthNotifier extends StateNotifier<AuthState> {
  AuthNotifier() : super(AuthState());

  void setAuthData({required String token, String? username}) {
    state = AuthState(token: token, username: username);
  }

  void clearAuthData() {
    state = AuthState();
  }
}

class AuthState {
  final String? token;
  final String? username;

  AuthState({this.token, this.username});

  bool get isAuthenticated => token != null && token!.isNotEmpty;

  AuthState copyWith({String? token, String? username}) {
    return AuthState(
      token: token ?? this.token,
      username: username ?? this.username,
    );
  }
}
