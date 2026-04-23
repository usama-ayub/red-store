import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:helloworld/providers/auth_provider.dart';
import 'package:helloworld/screens/constants.dart';
import 'package:helloworld/screens/main_screen.dart';
import 'package:helloworld/screens/register_screen.dart';
import 'package:shared_preferences/shared_preferences.dart';

class LoginScreen extends ConsumerWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    double topMargin = MediaQuery.of(context).padding.top;

    Future<void> loginUser(String _username, String _password) async {
      // Simulate login API
      const fakeToken = "abc123444";
      String username = _username ?? 'login';
      // Save to shared preferences
      final prefs = await SharedPreferences.getInstance();
      await prefs.setString('token', fakeToken);
      await prefs.setString('username', username);
      ref
          .read(authProvider.notifier)
          .setAuthData(token: fakeToken, username: username);
    }

    return Scaffold(
        body: Stack(
      children: [
        Positioned(
            top: -330,
            right: -330,
            child: Container(
              width: 600,
              height: 600,
              decoration: const BoxDecoration(
                  color: lightBlueColor, shape: BoxShape.circle),
            )),
        Positioned(
            top: -((1 / 4) * 500),
            right: -((1 / 4) * 500),
            child: Container(
              width: 450,
              height: 450,
              decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  border: Border.all(color: lightBlueColor, width: 2)),
            )),
        Positioned(
          left: -280,
          bottom: -120,
          child: Container(
            width: 350,
            height: 340,
            decoration: BoxDecoration(
                border: Border.all(color: lightBlueColor, width: 2)),
          ),
        ),
        Positioned(
          left: -258,
          bottom: -120,
          child: Transform.rotate(
            angle: -0.99999,
            child: Container(
              width: 372,
              height: 250,
              decoration: BoxDecoration(
                  border: Border.all(color: lightBlueColor, width: 2)),
            ),
          ),
        ),
        Padding(
          padding: EdgeInsets.symmetric(horizontal: 22),
          child: Column(
            children: [
              SizedBox(height: 60),
              const Text(
                "Login Here",
                textAlign: TextAlign.center,
                style: heading02,
              ),
              SizedBox(height: 10),
              Padding(
                  padding: EdgeInsets.symmetric(horizontal: 50),
                  child: Text(
                    "Welcome back you’ve been missed!",
                    textAlign: TextAlign.center,
                    style: TextStyle(fontSize: 18, color: blackColor),
                  )),
              SizedBox(height: 60),
              TextField(
                  decoration: InputDecoration(
                fillColor: lightBlueColor,
                filled: true,
                hintText: "Email",
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                    borderSide: BorderSide.none),
              )),
              SizedBox(height: 20),
              TextField(
                  decoration: InputDecoration(
                fillColor: lightBlueColor,
                filled: true,
                hintText: "Password",
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10),
                    borderSide: BorderSide.none),
              )),
              SizedBox(height: 15),
              Align(
                alignment: Alignment.centerRight,
                child: const Text(
                  "Forgot your password?",
                  style: TextStyle(
                      color: primaryColor,
                      fontSize: 16,
                      fontWeight: FontWeight.w500),
                ),
              ),
              SizedBox(height: 20),
              SizedBox(
                width: double.infinity,
                height: 60,
                child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    backgroundColor: primaryColor,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10)),
                  ),
                  onPressed: () async {
                    await loginUser('usama', '1234');
                    Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(
                            builder: (context) => const MainScreen()));
                  },
                  child: const Text(
                    "Sign In",
                    style: TextStyle(fontSize: 20, color: whiteColor),
                  ),
                ),
              ),
              SizedBox(height: 15),
              InkWell(
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const RegisterScreen()));
                },
                child: const Text(
                  "Create new account",
                  style: TextStyle(fontSize: 15, fontWeight: FontWeight.w500),
                ),
              ),
              SizedBox(height: 40),
              const Text(
                "Or continue with",
                style: TextStyle(
                    color: primaryColor,
                    fontSize: 16,
                    fontWeight: FontWeight.w500),
              ),
              SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset(
                      'assets/google.png',
                    ),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset('assets/facebook.png'),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    width: 60,
                    height: 44,
                    decoration: BoxDecoration(
                        color: Colors.grey.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(10)),
                    child: Image.asset('assets/apple.png'),
                  )
                ],
              )
            ],
          ),
        )
      ],
    ));
  }
}
