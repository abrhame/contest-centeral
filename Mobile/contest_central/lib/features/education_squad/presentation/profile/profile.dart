import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/utils/img.dart';
import 'card_data.dart';
import 'user_status.dart';

class ProfilePolygonRoute extends StatefulWidget {
  ProfilePolygonRoute();

  @override
  ProfilePolygonRouteState createState() => ProfilePolygonRouteState();
}

String name = "Nahom";

// get name from shared preference
Future<String> getName() async {
  final prefs = await SharedPreferences.getInstance();
  final name = prefs.getString('firstName');
  print("name: $name");
  return name!;
}

@override
void initState() {
  getName().then((value) {
    name = value;
  });
}

class ProfilePolygonRouteState extends State<ProfilePolygonRoute> {
    bool _oldpassword = true;
    bool _newpassword = true;
    bool _confirmpassword = true;
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
                      radius: 48.0,
                      backgroundImage:
                          AssetImage('assets/images/no_profile.png'),
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
                              "Nahom",
                              "Edit",
                              () => print("Edit"),
                            ),
                            cardData(
                              "Email",
                              "nhabtamu42@gmail.com",
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

                const SizedBox(height: 30,),

                Padding(
                  padding: const EdgeInsets.all(5),
                  child: Container(
                    
                    height: 500,
                    width: double.maxFinite,
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(5),
                      boxShadow: const [
                      BoxShadow(
                        color: Color.fromRGBO(149, 157, 165, 0.26),
                        offset: Offset(0, 8),
                        blurRadius: 6.0,
                      ),
                    ],
                    ),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                  
                        Padding(
                          padding: const EdgeInsets.only(left: 20, top: 25),
                          child: Text("Change Password", style: TextStyle( 
                            fontSize: 18,
                            fontWeight: FontWeight.w500,
                            color: Color.fromARGB(240, 34, 34, 34)),),
                        ),

                        Padding(
                          padding: const EdgeInsets.only(left: 25, top: 35, right: 35),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              
                              Text("Old Password", style: TextStyle( 
                                fontSize: 14,
                              
                                color: Color.fromARGB(255, 117, 126, 141)),),

                              SizedBox(height: 10,),
                              
                              Container(
                              height: 50,
                              child: TextField(
                                cursorColor: Color.fromARGB(255, 102, 102, 102),
                                obscureText: _oldpassword,
                                
                                decoration: InputDecoration(
                                  filled: true,
                                    fillColor: Color.fromARGB(100, 203, 213, 224),
                                    
                                    suffixIcon:   Container(
                                      margin: EdgeInsets.all(5),
                                        
                                      
                                      decoration: BoxDecoration(
                                        border: Border(
                                          left: BorderSide(
                                            color: Color.fromARGB(255, 203, 213, 224), // Color of the left border
                                            width: 1.0,
                                            
                                            
                                            
                                          ),
                                        ),
                                      ),
                                      child: IconButton(
                                        icon: Icon(
                                          _oldpassword ? Icons.visibility : Icons.visibility_off,
                                        ),
                                        onPressed: () {
                                          setState(() {
                                            _oldpassword = !_oldpassword;
                                          });
                                        },
                                      ),
                               ),
                                    
                                
                                    focusedBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                        borderSide: BorderSide(
                                            color: Color.fromARGB(255, 217, 218, 219))),
                                    enabledBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                      borderSide: BorderSide(
                                          color: Color.fromARGB(255, 217, 218, 219)),
                                    )),
                              ),
                            ),
                            SizedBox(height: 25,),
                            Text("New Password", style: TextStyle( 
                                fontSize: 14,
                              
                                color: Color.fromARGB(255, 117, 126, 141)),),

                              SizedBox(height: 10,),
                              
                              Container(
                              height: 50,
                              child: TextField(
                                cursorColor: Color.fromARGB(255, 102, 102, 102),
                                obscureText: _newpassword,
                                
                                decoration: InputDecoration(
                                  filled: true,
                                    fillColor: Color.fromARGB(100, 203, 213, 224),
                                    
                                    suffixIcon: Container(
                                      margin: EdgeInsets.all(5),
                                        
                                      
                                      decoration: BoxDecoration(
                                        border: Border(
                                          left: BorderSide(
                                            color: Color.fromARGB(255, 203, 213, 224), // Color of the left border
                                            width: 1.0,
                                            
                                            
                                            
                                          ),
                                        ),
                                      ),
                                      child: IconButton(
                                        icon: Icon(
                                          _newpassword ? Icons.visibility : Icons.visibility_off,
                                        ),
                                        onPressed: () {
                                          setState(() {
                                            _newpassword = !_newpassword;
                                          });
                                        },
                                      ),
                               ),
                                    
                                
                                    
                                    focusedBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                        borderSide: BorderSide(
                                            color: Color.fromARGB(255, 217, 218, 219))),
                                    enabledBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                      borderSide: BorderSide(
                                          color: Color.fromARGB(255, 217, 218, 219)),
                                    )),
                              ),
                            ),

                            SizedBox(height: 25,),
                            Text("Confirm Password", style: TextStyle( 
                                fontSize: 14,
                              
                                color: Color.fromARGB(255, 117, 126, 141)),),

                              SizedBox(height: 10,),
                              
                              Container(
                              height: 50,
                              
                              child: TextField(
                                cursorColor: Color.fromARGB(255, 102, 102, 102),
                                obscureText: _confirmpassword,
                                
                                decoration: InputDecoration(
                                    filled: true,
                                    fillColor: Color.fromARGB(100, 203, 213, 224),
                                    suffixIcon:  Container(
                                      margin: EdgeInsets.all(5),
                                        
                                      
                                      decoration: BoxDecoration(
                                        border: Border(
                                          left: BorderSide(
                                            color: Color.fromARGB(255, 203, 213, 224), // Color of the left border
                                            width: 1.0,
                                            
                                            
                                            
                                          ),
                                        ),
                                      ),
                                      child: IconButton(
                                        icon: Icon(
                                          _confirmpassword ? Icons.visibility : Icons.visibility_off,
                                        ),
                                        onPressed: () {
                                          setState(() {
                                            _confirmpassword = !_confirmpassword;
                                          });
                                        },
                                      ),
                               ),
                                    
                                
                                    focusedBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                        borderSide: BorderSide(
                                            color: Color.fromARGB(255, 217, 218, 219))),
                                    enabledBorder: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(18),
                                      borderSide: BorderSide(
                                          color: Color.fromARGB(255, 217, 218, 219)),
                                    )),
                              ),
                            ),
                            SizedBox(height: 20,),
                            Center(
                              child: Container(
                                  height: 40,
                                  width: 150,
                                  child: ElevatedButton(
                                    style: ElevatedButton.styleFrom(
                                      // padding: EdgeInsets.symmetric(vertical: 12.0, horizontal: 24.0),
                                      shape: RoundedRectangleBorder(
                                        borderRadius: BorderRadius.circular(15.0),
                                        // side: BorderSide(color: Colors.blue), // Border color
                                      ),
                                      // elevation: 4.0, // Elevation
                                      backgroundColor: const Color.fromARGB(
                                          255, 38, 78, 202), // Background color
                                    ),
                                    onPressed: () {},
                                    child: const Text(
                                      "Reset Password",
                                      style: TextStyle(
                                          fontWeight: FontWeight.w400, color: Colors.white),
                                    ),
                                  ),
                                ),
                            ),
                                              
                            ],
                          ),
                        )

                       

                      ],
                    ),
                  ),
                ),

                 SizedBox(
                          height: 100,),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
