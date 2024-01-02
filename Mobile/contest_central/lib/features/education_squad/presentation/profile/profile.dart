import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../../../../core/utils/img.dart';
import 'card_data.dart';
import 'user_status.dart';

class ProfilePolygonRoute extends StatefulWidget {
  ProfilePolygonRoute();

  @override
  ProfilePolygonRouteState createState() => ProfilePolygonRouteState();
}

class ProfilePolygonRouteState extends State<ProfilePolygonRoute> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: NestedScrollView(
        headerSliverBuilder: (BuildContext context, bool innerBoxIsScrolled) {
          return <Widget>[
            SliverAppBar(
              backgroundColor: Color.fromARGB(255, 61, 61, 63),
              expandedHeight: 140.0,
              systemOverlayStyle: const SystemUiOverlayStyle(
                  // statusBarColor: Colors.white,
                  statusBarBrightness: Brightness.light),
              floating: false,
              pinned: true,
              flexibleSpace: FlexibleSpaceBar(
                background: Image.asset(Img.get('OIP.jpg'), fit: BoxFit.cover),
              ),
              leading: IconButton(
                icon: const Icon(Icons.arrow_back_ios, color: Colors.white),
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
              actions: <Widget>[
                IconButton(
                  icon: const Icon(
                    Icons.search,
                    color: Colors.white,
                  ),
                  onPressed: () {},
                ), // overflow menu
                PopupMenuButton<String>(
                  onSelected: (String value) {},
                  itemBuilder: (context) => [
                    const PopupMenuItem(
                      value: "Settings",
                      child: Text("Settings"),
                    ),
                  ],
                )
              ],
              bottom: PreferredSize(
                preferredSize:
                    Size.fromHeight(MediaQuery.of(context).size.height * 0.09),
                child: Container(
                  transform: Matrix4.translationValues(-100, 50, 0),
                  child: CircleAvatar(
                    radius: 50,
                    backgroundColor: const Color.fromARGB(255, 255, 255, 255),
                    child: CircleAvatar(
                      radius: 48,
                      backgroundImage: AssetImage(Img.get("image 1.png")),
                    ),
                  ),
                ),
              ),
            ),
          ];
        },
        body: SingleChildScrollView(
          child: Container(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: Column(
              children: <Widget>[
                Container(height: 15),
                // update button
                Row(
                  children: [
                    const Spacer(),
                    Padding(
                      padding: const EdgeInsets.all(10.0),
                      child: Container(
                        height: 37,
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            backgroundColor:
                                const Color.fromARGB(255, 215, 224, 248),
                            shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(20)),
                          ),
                          child: const Row(
                            children: [
                              Icon(
                                Icons.photo_camera,
                                color: Color.fromARGB(255, 46, 45, 45),
                                size: 20,
                              ),
                              Text(
                                " Update profile",
                                style: TextStyle(
                                  color: Color.fromARGB(255, 46, 45, 45),
                                  fontSize: 14,
                                ),
                              ),
                            ],
                          ),
                          onPressed: () {
                            // Navigator.pushReplacement(
                            //   context,
                            //   MaterialPageRoute(
                            //     builder: (context) => const ESquadDashBoard(),
                            //   ),
                            // );
                          },
                        ),
                      ),
                    ),
                  ],
                ),
                const SizedBox(
                  height: 20,
                ),

                // Large card with shadow and user information
                Container(
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(8.0),
                    border: Border.all(
                      color: const Color.fromARGB(91, 207, 207, 207),
                      width: 1,
                    ),
                    boxShadow: const [
                      BoxShadow(
                        color: Color.fromRGBO(149, 157, 165, 0.26),
                        offset: Offset(0, 8),
                        blurRadius: 6.0,
                      ),
                    ],
                  ),
                  child: Column(
                    children: [
                      // user information
                      Container(
                        padding: const EdgeInsets.all(20),
                        child: Column(
                          children: [
                            cardData(
                              "Name",
                              "Anima Agarwal",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Email",
                              "geme@gmail.com",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Phone Number",
                              "+251 911 111 111",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Gender",
                              "Female",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Date of Birth",
                              "Jun 2",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Address",
                              "Addis Ababa, Ethiopia",
                              "Edit",
                              () => print("Edit"),
                            ),
                          ],
                        ),
                      ),
                      // divider
                      Container(
                        height: 1,
                        color: const Color.fromARGB(255, 234, 234, 234),
                      ),
                      // user information
                    ],
                  ),
                ),
                const SizedBox(
                  height: 20,
                ),
                StatusData(),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
