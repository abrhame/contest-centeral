import 'package:flutter/material.dart';

import 'list.dart';

class TopGroups extends StatefulWidget {
  @override
  _TopGroupsState createState() => _TopGroupsState();
}

class _TopGroupsState extends State<TopGroups> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Padding(
          padding: const EdgeInsets.only(left: 10, right: 10, top: 20),
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white,

              borderRadius:
                  BorderRadius.circular(8.0), // Set your desired border radius
              boxShadow: const [
                BoxShadow(
                  color: Color.fromRGBO(149, 157, 165, 0.2), // Shadow color
                  offset: Offset(0, 8), // Offset in the x, y direction
                  blurRadius: 24.0, // Blur radius
                ),
              ],
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(5.0),
                      child: Container(
                        decoration: const BoxDecoration(
                          shape: BoxShape.circle,
                          color: const Color(0xffFFDE9B),
                          // Change the color of the circle background
                          boxShadow: [
                            BoxShadow(
                              color: Colors.black12,
                              blurRadius: 1,
                              offset: Offset(0, 4),
                            ),
                          ],
                        ),
                        padding: const EdgeInsets.all(8),
                        child: const Icon(Icons.groups,
                            color: Color.fromARGB(189, 31, 31,
                                31) // Change the color of the chart icon
                            ),
                      ),
                    ),
                    const Text(
                      "Top Groups",
                      style: TextStyle(
                          fontSize: 20,
                          color: Color.fromARGB(255, 104, 101, 101)),
                    ),
                  ],
                ),
                Lists(rank: "1", group: "Group 46", percent: "80%"),
                Lists(rank: "2", group: "Group 45", percent: "80%"),
                Lists(rank: "3", group: "Group 41", percent: "80%"),
                Lists(rank: "4", group: "Group 42", percent: "80%"),
                Lists(rank: "5", group: "Group 43", percent: "80%"),
              ],
            ),
          )),
    );
  }
}
