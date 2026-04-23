import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:helloworld/providers/auth_provider.dart';
import 'package:helloworld/providers/navigation_provider.dart';
import 'package:helloworld/screens/onboarding_screen.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ProfileScreen extends ConsumerWidget {
  const ProfileScreen({super.key});
  @override
  Widget build(BuildContext context, WidgetRef ref) {
    Future<void> logout() async {
      final prefs = await SharedPreferences.getInstance();
      await prefs.clear();
      ref.read(navigationProvider.notifier).updateIndex(0);
      ref.read(authProvider.notifier).clearAuthData();

      Navigator.pushAndRemoveUntil(
        context,
        MaterialPageRoute(builder: (_) => const OnBoardingScreen()),
        (route) => false,
      );
    }

    return Column(mainAxisAlignment: MainAxisAlignment.center, children: [
      Text(
        "Profile",
        style: const TextStyle(fontSize: 28, fontWeight: FontWeight.w600),
      ),
      ElevatedButton(
          onPressed: () async {
            await logout();
          },
          child: const Text('Logout'))
    ]);
  }
}
