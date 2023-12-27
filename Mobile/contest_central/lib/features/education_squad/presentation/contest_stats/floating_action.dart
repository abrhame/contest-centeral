import 'package:flutter/material.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';

import '../../../../core/utils/my_colors.dart';
import '../contest_add/add_contest.dart';

Widget buildSpeedDial(BuildContext context) {
  return SpeedDial(
    elevation: 2,
    // icondata
    icon: Icons.add,
    // icon color
    iconTheme: const IconThemeData(color: Colors.white),

    activeIcon: Icons.close,
    // animatedIcon: AnimatedIcons.menu_close,
    // animatedIconTheme: const IconThemeData(color: Colors.white),
    curve: Curves.linear,
    overlayColor: Colors.black,
    overlayOpacity: 0.8,

    backgroundColor: Color.fromARGB(255, 62, 77, 239),
    children: [
      SpeedDialChild(
        elevation: 2,
        label: "Add New Contest",
        child: const Icon(Icons.create, color: MyColors.grey_80),
        backgroundColor: Colors.white,
        onTap: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => AddContest()),
          );
        },
      ),
    ],
  );
}
