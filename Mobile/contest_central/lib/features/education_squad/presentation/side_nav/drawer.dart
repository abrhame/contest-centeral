import 'dart:developer';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../contest_list/contest_list.dart';
import '../contest_stats/contest_detail.dart';

class EndDrawers extends StatefulWidget {
  const EndDrawers({super.key});

  @override
  State<EndDrawers> createState() => _EndDrawersState();
}

class _EndDrawersState extends State<EndDrawers> {
  Future<void> clearPreference(String key) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    prefs.remove(key);
  }

  @override
  Widget build(BuildContext context) {
    return Drawer(
      backgroundColor: Colors.white,
      child: ListView(
        children: [
          Padding(
            padding: const EdgeInsets.all(40.0),
            child: Image.asset('assets/images/logo 1.png'),
          ),
          ListTile(
            leading: const Icon(
              Icons.dashboard,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Dashboard',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () {
              // Navigator.of(context).push(
              //   MaterialPageRoute(
              //     builder: (context) => AboutUs(),
              //   ),
              // );
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.bar_chart,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Contests',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () {
              Navigator.pop(context);
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => const ContestDetail(),
                ),
              );
            },
          ),
          // ListTile(
          //   leading: const Icon(
          //     Icons.privacy_tip,
          //     color: Color.fromARGB(255, 63, 66, 80),
          //   ),
          //   title: const Text(
          //     'Privacy',
          //     style: TextStyle(
          //       fontFamily: 'Urbanist-Bold',
          //       fontSize: 16,
          //     ),
          //   ),
          //   onTap: () {
          //     // Handle Privacy action
          //     Navigator.pop(context); // Close the drawer
          //   },
          // ),

          ListTile(
            leading: const Icon(
              Icons.group,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Users',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () async {
              // close the drawer
              Navigator.pop(context);
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.settings,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Settings',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () {
              // Navigator.of(context).push(
              //   MaterialPageRoute(
              //     builder: (context) => FAQScreen(),
              //   ),
              // );
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.emoji_events,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Leaders Board',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () {
              // Navigator.of(context).push(
              //   MaterialPageRoute(
              //     builder: (context) => FAQScreen(),
              //   ),
              // );
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.groups,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Members',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () {
              // Navigator.of(context).push(
              //   MaterialPageRoute(
              //     builder: (context) => FAQScreen(),
              //   ),
              // );
            },
          ),

          ListTile(
            leading: const Icon(
              Icons.logout,
              color: Color.fromARGB(255, 63, 66, 80),
            ),
            title: const Text(
              'Log Out',
              style: TextStyle(
                fontFamily: 'Urbanist-Bold',
                fontSize: 16,
              ),
            ),
            onTap: () async {
              // await clearPreference('visited_before');
              // // exit(0);
              // Restart.restartApp();
            },
          ),
        ],
      ),
    );
  }
}
