import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:helloworld/screens/demo_screen.dart';
import 'package:helloworld/screens/main_screen.dart';
import 'package:helloworld/screens/onboarding_screen.dart';
import 'package:helloworld/screens/splash_screen.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'providers/auth_provider.dart';

void main() {
  runApp(
    const ProviderScope(
      child: MyApp(),
    ),
  );
}

class MyApp extends ConsumerStatefulWidget {
  const MyApp({super.key});

  @override
  ConsumerState<MyApp> createState() => _MyAppState();
}

class _MyAppState extends ConsumerState<MyApp> {
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _initAuth();
  }

  Future<void> initializeAuth(WidgetRef ref) async {
    final prefs = await SharedPreferences.getInstance();
    final token = prefs.getString('token');
    final username = prefs.getString('username');

    if (token != null && token.isNotEmpty) {
      ref.read(authProvider.notifier).setAuthData(
            token: token,
            username: username ?? '',
          );
    }
  }

  Future<void> _initAuth() async {
    await initializeAuth(ref);
    await Future.delayed(const Duration(seconds: 6));
    setState(() {
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    final authState = ref.watch(authProvider);

    if (_isLoading) {
      return const MaterialApp(
        debugShowCheckedModeBanner: false,
        home: SplashScreen(),
      );
    }
    // if (_isLoading) {
    //   return const MaterialApp(
    //     home: Scaffold(
    //       body: Center(child: CircularProgressIndicator()),
    //     ),
    //   );
    // }

    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: authState.isAuthenticated
          // ? const DemoScreen()
          ? const MainScreen()
          : const OnBoardingScreen(),
    );
  }
}
