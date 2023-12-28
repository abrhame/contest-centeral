import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../../../education_squad/presentation/dashboard/home.dart';
// import '../../../education_squad/presentation/dashboard/home_screen.dart';

class LoginScreen extends StatefulWidget {
  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    SystemChrome.setSystemUIOverlayStyle(const SystemUiOverlayStyle(
        statusBarColor: Colors.transparent,
        statusBarIconBrightness: Brightness.dark));

    return Scaffold(
      backgroundColor: const Color(0xffF8FAFF),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              const SizedBox(height: 70),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Image.asset(
                  'assets/images/logo 1.png',
                  height: 50,
                  width: 50,
                ),
              ),
              const SizedBox(height: 20),
              const Text(
                'Sign in',
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                ),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 20),
              _buildTextField('Email', Icons.email),
              const SizedBox(height: 10),
              _buildPasswordField(),
              const SizedBox(height: 5),
              Padding(
                padding: const EdgeInsets.only(right: 15),
                child: Row(
                  children: [
                    Checkbox(
                      value: false, // Manage state accordingly
                      onChanged: (value) {
                        // Handle checkbox state change
                      },
                    ),
                    const Text('Remember me'),
                    const Spacer(),
                    GestureDetector(
                      onTap: () {
                        // Implement forgot password functionality
                      },
                      child: const Text(
                        'Forgot Password?',
                        // under line text

                        style: TextStyle(
                          color: Colors.blue,
                          // decoration: TextDecoration.underline,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              //  const SizedBox(height: 20),
              Padding(
                padding: const EdgeInsets.all(15.0),
                child: Container(
                  width: double.infinity,
                  height: 45,
                  child: ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color.fromARGB(255, 71, 109, 234),
                      shape: RoundedRectangleBorder(
                          borderRadius: new BorderRadius.circular(20)),
                    ),
                    child: const Text(
                      "Sign In",
                      style: TextStyle(
                          color: Color.fromARGB(255, 255, 255, 255),
                          fontSize: 17,
                          fontWeight: FontWeight.bold),
                    ),
                    onPressed: () {
                      // ContestDetail()
                      Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const ESquadDashBoard(),
                        ),
                      );
                    },
                  ),
                ),
              ),

              const SizedBox(height: 3),
              // ----- OR ----- text with divider
              const Padding(
                padding: EdgeInsets.all(15.0),
                child: Row(
                  children: [
                    Expanded(
                      child: Divider(
                        color: Color.fromARGB(255, 224, 224, 224),
                      ),
                    ),
                    Padding(
                      padding: EdgeInsets.symmetric(horizontal: 8.0),
                      child: Text(
                        'OR',
                        style: TextStyle(
                          color: Color.fromARGB(255, 90, 90, 90),
                        ),
                      ),
                    ),
                    Expanded(
                      child: Divider(
                        color: Color.fromARGB(255, 224, 224, 224),
                      ),
                    ),
                  ],
                ),
              ),
              //  const SizedBox(height: 10),
              Padding(
                padding: const EdgeInsets.all(15.0),
                child: Container(
                  color: Colors.white,
                  width: double.infinity,
                  height: 45,
                  child: ElevatedButton.icon(
                    onPressed: () {
                      // Implement sign in with Google functionality
                    },
                    style: ElevatedButton.styleFrom(
                      surfaceTintColor: Colors.white,
                      foregroundColor: const Color.fromARGB(255, 255, 255, 255),
                      backgroundColor: Colors.white,
                      shadowColor: Colors.white,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(20),
                        side: const BorderSide(
                          color: Color.fromARGB(
                              255, 236, 236, 236), // Grey border color
                        ),
                      ),
                    ),
                    icon: Image.asset(
                      'assets/images/google-icon-logo-png-transparent.png', // Replace with your Google icon file path
                      height: 20,
                      width: 20,
                    ),
                    label: const Text('Continue with Google',
                        style: TextStyle(
                            color: Color.fromARGB(255, 41, 41, 41),
                            fontSize: 17,
                            fontWeight: FontWeight.bold)),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildTextField(String label, IconData icon) {
    return // Fllname label and input field
        Padding(
      padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            'Email',
            style: TextStyle(
              fontSize: 19,
              color: Colors.grey,
              fontWeight: FontWeight.bold,
            ),
          ),
          const SizedBox(
            height: 10,
          ),
          SizedBox(
            height: 40,
            child: TextFormField(
              controller: _emailController,
              decoration: const InputDecoration(
                hintText: 'example@gmail.com',
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(
                    color: Color(0xffDFE2E6),
                  ),
                  borderRadius: BorderRadius.all(
                    Radius.circular(10.0),
                  ),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(
                    color: Color(0xffDFE2E6),
                  ),
                  borderRadius: BorderRadius.all(
                    Radius.circular(30.0),
                  ),
                ),
                filled: true,
                fillColor: Colors.white,
                prefixIcon: Icon(
                  Icons.email,
                  color: Color(0xffDFE2E6),
                ),
                hintStyle: TextStyle(
                  color: Color(0xffDFE2E6),
                  // Adjust the top padding as needed
                  height: 1.5, // Increase this value to add more top padding
                ),
                contentPadding: EdgeInsets.symmetric(
                    vertical: 1.0), // Adjust the vertical padding as needed
              ),
            ),
          ),
        ],
      ),
    );
    // Fllname label an;
  }

  Widget _buildPasswordField() {
    return // Password label and input field
        Padding(
      padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            'Passsword',
            style: TextStyle(
              fontSize: 19,
              color: Colors.grey,
              fontWeight: FontWeight.bold,
            ),
          ),
          const SizedBox(
            height: 10,
          ),
          SizedBox(
            height: 40,
            child: TextFormField(
              controller: _passwordController,
              obscureText: true,
              decoration: const InputDecoration(
                hintText: "Choose a password",
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(
                    color: Color(0xffDFE2E6),
                  ),
                  borderRadius: BorderRadius.all(
                    Radius.circular(10.0),
                  ),
                ),
                focusedBorder: OutlineInputBorder(
                  borderSide: BorderSide(
                    color: Color(0xffDFE2E6),
                  ),
                  borderRadius: BorderRadius.all(
                    Radius.circular(30.0),
                  ),
                ),

                filled: true,
                fillColor: Colors.white,
                prefixIcon: Icon(
                  Icons.vpn_key,
                  color: Color(0xffDFE2E6),
                ),
                hintStyle: TextStyle(
                  color: Color(0xffDFE2E6),
                  // Adjust the top padding as needed
                  height: 1.5, // Increase this value to add more top padding
                ),
                contentPadding: EdgeInsets.symmetric(
                    vertical: 1.0), // Adjust the vertical padding as needed
              ),
            ),
          ),
        ],
      ),
    );
  }
}
