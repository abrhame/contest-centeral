import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../../../education_squad/presentation/dashboard/home.dart';
import 'login.dart';

class SignUpScreen extends StatefulWidget {
  @override
  State<SignUpScreen> createState() => _SignUpScreenState();
}

class _SignUpScreenState extends State<SignUpScreen> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  bool isLoading = false;
  bool isPasswordVisible = false;

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
                'Create Account',
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                ),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 20),
              _buildNameField('Name', Icons.person),
              _buildTextField('Email', Icons.email),
              const SizedBox(height: 10),
              _buildPasswordField(),
              const SizedBox(height: 5),
              Padding(
                padding: const EdgeInsets.all(15.0),
                child: Container(
                  width: double.infinity,
                  height: 45,
                  child: ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color.fromARGB(255, 71, 109, 234),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(20)),
                    ),
                    child: isLoading
                        ? CircularProgressIndicator(
                            valueColor: AlwaysStoppedAnimation<Color>(
                              Colors.white,
                            ),
                          )
                        : const Text(
                            "Sign Up",
                            style: TextStyle(
                                color: Color.fromARGB(255, 255, 255, 255),
                                fontSize: 17,
                                fontWeight: FontWeight.bold),
                          ),
                    onPressed: () {
                      if (_validateInputs()) {
                        // Show loading indicator
                        setState(() {
                          isLoading = true;
                        });

                        // Simulate some asynchronous task, like an API call
                        Future.delayed(const Duration(seconds: 3), () {
                          // Hide loading indicator
                          setState(() {
                            isLoading = false;
                          });

                          // Navigate to the next route
                          Navigator.pushReplacement(
                            context,
                            MaterialPageRoute(
                              builder: (context) => const ESquadDashBoard(),
                            ),
                          );
                        });
                      }
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
                        'Already have an account?',
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
                      // SignUpScreen()
                      Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(
                          builder: (context) => LoginScreen(),
                        ),
                      );
                    },
                    style: ElevatedButton.styleFrom(
                      surfaceTintColor: Color(0xff212121),
                      foregroundColor: const Color(0xff212121),
                      backgroundColor: Color(0xff212121),
                      shadowColor: Colors.white,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(20),
                        side: const BorderSide(
                          color: Color.fromARGB(
                              255, 236, 236, 236), // Grey border color
                        ),
                      ),
                    ),
                    // email icon
                    icon: const Icon(
                      Icons.email,
                      color: Color(0xffDFE2E6),
                    ),
                    label: const Text('Login with Email',
                        style: TextStyle(
                            color: Color.fromARGB(255, 233, 233, 233),
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

  Widget _buildNameField(String label, IconData icon) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            'Full Name',
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
              controller: _nameController,
              decoration: const InputDecoration(
                hintText: 'John Doe',
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
                  Icons.person,
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

  Widget _buildTextField(String label, IconData icon) {
    return Padding(
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
  }

  Widget _buildPasswordField() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 10.0, vertical: 10.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            'Password',
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
              obscureText: !isPasswordVisible,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Please enter a password';
                }
                if (value.length < 8) {
                  return 'Password must be at least 8 characters';
                }
                if (!RegExp(r'[a-zA-Z]').hasMatch(value)) {
                  return 'Password must contain at least one letter';
                }
                return null;
              },
              decoration: InputDecoration(
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
                suffixIcon: IconButton(
                  icon: Icon(
                    isPasswordVisible ? Icons.visibility : Icons.visibility_off,
                    color: Color(0xffDFE2E6),
                  ),
                  onPressed: () {
                    setState(() {
                      isPasswordVisible = !isPasswordVisible;
                    });
                  },
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

  bool _validateInputs() {
    final name = _nameController.text;
    final email = _emailController.text;
    final password = _passwordController.text;

    if (name.isEmpty || email.isEmpty || password.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Please enter all details'),
          backgroundColor: Colors.red,
        ),
      );
      return false;
    }

    if (!RegExp(r'^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$')
        .hasMatch(email)) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Please enter a valid email'),
          backgroundColor: Colors.red,
        ),
      );
      return false;
    }

    return true;
  }
}
