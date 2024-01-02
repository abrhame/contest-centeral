import 'package:flutter/material.dart';

class AddContest extends StatefulWidget {
  @override
  _AddContestState createState() => _AddContestState();
}

class _AddContestState extends State<AddContest> {
  late int showingTooltip;
  List<Map<String, String>> problems = [];
  @override
  void initState() {
    showingTooltip = -1;
    super.initState();
  }

  void addProblem(String name, String status) {
    setState(() {
      problems.add({'name': name, 'status': status});
    });
  }

  void removeProblem(int indx) {
    setState(() {
      problems.removeAt(indx);
    });
  }

  String _selectedUniversity = "select";
  List<String> _selectedUniversities = [];
  String _selectedCountry = "select";
  List<String> _selectedCountries = [];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.grey[100],
        appBar: AppBar(
          leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
            },
            icon: const Icon(
              Icons.arrow_back_ios,
              size: 24,
              color: Color.fromARGB(255, 120, 116, 134),
            ),
          ),
          title: const SizedBox(
            width: 130,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(
                  Icons.corporate_fare,
                  size: 20,
                  color: Color.fromARGB(255, 87, 88, 91),
                ),
                Text(
                  "/",
                  style: TextStyle(
                      fontSize: 20, color: Color.fromARGB(255, 209, 213, 219)),
                ),
                Text(
                  "Contests",
                  style: TextStyle(
                      fontSize: 20, color: Color.fromARGB(255, 107, 114, 128)),
                )
              ],
            ),
          ),
          actions: const [
            Icon(
              Icons.notifications_outlined,
              color: Color.fromARGB(255, 120, 116, 134),
            ),
            SizedBox(
              width: 7,
            ),
            CircleAvatar(
              radius: 15.0,
              backgroundImage: NetworkImage(
                  'https://th.bing.com/th/id/R.0f36a9b7563d5a0787b5661ce63f3ee8?rik=cJxNXWv6Gt5s8g&riu=http%3a%2f%2fadvantagebodylanguage.com%2fwp-content%2fuploads%2f2015%2f12%2fgewoman.jpg&ehk=nR1PFEO%2fHz1YZ3XLQsKWjtU3Ga%2boY%2f4NzLcCMXB3uYU%3d&risl=&pid=ImgRaw&r=0'),
            ),
            //  SizedBox(width:2,),
            Icon(
              Icons.expand_more,
              color: Color.fromARGB(255, 41, 45, 50),
            ),
            SizedBox(
              width: 20,
            )
          ],
        ),
        body: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(20),
            child:
                Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
              const Text(
                "Contentasts and Contest Url",
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
              const SizedBox(
                height: 20,
              ),
              const Text(
                "Country",
                style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                    color: Color.fromARGB(255, 107, 114, 128)),
              ),
              const SizedBox(
                height: 10,
              ),
              Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    width: MediaQuery.of(context).size.width * 0.9,
                    height: 50,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(5),
                      color: Colors.white,
                    ),
                    child: Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 15),
                      child: DropdownButton(
                        value: _selectedCountry,
                        icon: const Padding(
                          padding: EdgeInsets.only(left: 200.0),
                          child: Icon(Icons.expand_more),
                        ),
                        iconSize: 24,
                        elevation: 16,
                        underline: Container(
                          height: 2,
                        ),
                        //    style: const TextStyle(font: 150), // Set a fixed width
                        items: const [
                          DropdownMenuItem(
                            value: "select",
                            child: Text(
                              "Select",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                          DropdownMenuItem(
                            value: "Ethiopia",
                            child: Text(
                              "Ethiopia",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                          DropdownMenuItem(
                            value: "Ghana",
                            child: Text(
                              "Ghana",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                        ],
                        onChanged: (String? newValue) {
                          setState(() {
                            _selectedCountry = newValue!;
                            if (_selectedCountry != "select" &&
                                !_selectedCountries.contains(newValue)) {
                              _selectedCountries.add(newValue);
                            }
                          });
                        },
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  const Text(
                    "University",
                    style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w400,
                        color: Color.fromARGB(255, 107, 114, 128)),
                  ),
                  SingleChildScrollView(
                    child: Wrap(
                      spacing: 8.0,
                      direction: Axis.horizontal,
                      children: _selectedCountries.map((item) {
                        return Chip(
                          label: Text(item),
                          onDeleted: () {
                            setState(() {
                              _selectedCountries.remove(item);
                              _selectedCountry = "select";
                            });
                          },
                        );
                      }).toList(),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width * 0.9,
                    height: 50,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(5),
                      color: Colors.white,
                    ),
                    child: Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 15),
                      child: DropdownButton(
                        value: _selectedCountry,
                        icon: const Padding(
                          padding: EdgeInsets.only(left: 200.0),
                          child: Icon(Icons.expand_more),
                        ),
                        iconSize: 24,
                        elevation: 16,
                        underline: Container(
                          height: 2,
                        ),
                        //    style: const TextStyle(font: 150), // Set a fixed width
                        items: const [
                          DropdownMenuItem(
                            value: "select",
                            child: Text(
                              "Select",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                          DropdownMenuItem(
                            value: "AASTU",
                            child: Text(
                              "AASTU",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                          DropdownMenuItem(
                            value: "AAiT",
                            child: Text(
                              "AAiT",
                              style: TextStyle(
                                color: Color.fromARGB(255, 147, 150, 153),
                              ),
                            ),
                          ),
                        ],
                        onChanged: (String? newValue) {
                          setState(() {
                            _selectedCountry = newValue!;
                            if (_selectedCountry != "select" &&
                                !_selectedCountries.contains(newValue)) {
                              _selectedCountries.add(newValue);
                            }
                          });
                        },
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  SingleChildScrollView(
                    child: Wrap(
                      spacing: 8.0,
                      direction: Axis.horizontal,
                      children: _selectedCountries.map((item) {
                        return Chip(
                          label: Text(item),
                          onDeleted: () {
                            setState(() {
                              _selectedCountries.remove(item);
                              _selectedCountry = "select";
                            });
                          },
                        );
                      }).toList(),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                ],
              ),

              Wrap(
                spacing: 8.0,
                direction: Axis.horizontal,
                children: _selectedUniversities.map((item) {
                  return Chip(
                    label: Text(item),
                    onDeleted: () {
                      setState(() {
                        _selectedUniversities.remove(item);

                        _selectedUniversity = "select";
                      });
                    },
                  );
                }).toList(),
              ),

              const SizedBox(
                height: 30,
              ),
              const Text(
                "Contest Name",
                style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                    color: Color.fromARGB(255, 107, 114, 128)),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                height: 50,
                child: const TextField(
                  cursorColor: Color.fromARGB(255, 102, 102, 102),
                  decoration: InputDecoration(
                      focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                              color: Color.fromARGB(255, 217, 218, 219))),
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(
                            color: Color.fromARGB(255, 217, 218, 219)),
                      )),
                ),
              ),
              const SizedBox(
                height: 20,
              ),
              const Text(
                "Contest URL",
                style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                    color: Color.fromARGB(255, 107, 114, 128)),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                height: 50,
                child: const TextField(
                  cursorColor: Color.fromARGB(255, 102, 102, 102),
                  decoration: InputDecoration(
                      focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                              color: Color.fromARGB(255, 217, 218, 219))),
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(
                            color: Color.fromARGB(255, 217, 218, 219)),
                      )),
                ),
              ),
              const SizedBox(
                height: 30,
              ),
              const Text(
                "Problems",
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.w500),
              ),
              const SizedBox(
                height: 30,
              ),
              const Text(
                "Problem Name",
                style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                    color: Color.fromARGB(255, 107, 114, 128)),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                height: 50,
                child: const TextField(
                  cursorColor: Color.fromARGB(255, 102, 102, 102),
                  decoration: InputDecoration(
                      focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                              color: Color.fromARGB(255, 217, 218, 219))),
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(
                            color: Color.fromARGB(255, 217, 218, 219)),
                      )),
                ),
              ),

              const SizedBox(
                height: 20,
              ),
              const Text(
                "Problem URL",
                style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                    color: Color.fromARGB(255, 107, 114, 128)),
              ),
              const SizedBox(
                height: 10,
              ),
              Container(
                height: 50,
                child: const TextField(
                  cursorColor: Color.fromARGB(255, 102, 102, 102),
                  decoration: InputDecoration(
                      focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                              color: Color.fromARGB(255, 217, 218, 219))),
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(
                            color: Color.fromARGB(255, 217, 218, 219)),
                      )),
                ),
              ),
              const SizedBox(
                height: 20,
              ),

              Container(
                width: 130,
                height: 40,
                child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    // padding: EdgeInsets.symmetric(vertical: 12.0, horizontal: 24.0),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(6.0),
                      // side: BorderSide(color: Colors.blue), // Border color
                    ),
                    // elevation: 4.0, // Elevation
                    backgroundColor: const Color.fromARGB(255, 38, 78, 202),
                  ),
                  onPressed: () {
                    addProblem("LETTER", "Accepted");
                  },
                  child: const Text(
                    "Add Problem",
                    style: TextStyle(
                        fontWeight: FontWeight.w400, color: Colors.white),
                  ),
                ),
              ),

              const SizedBox(
                height: 20,
              ),

              Container(
                width: double.maxFinite,
                height: 60,
                decoration: BoxDecoration(
                    border: Border.all(
                        width: 1,
                        color: const Color.fromARGB(255, 229, 231, 235)),
                    color: const Color.fromARGB(255, 249, 250, 251),
                    borderRadius: const BorderRadius.only(
                        topLeft: Radius.circular(12),
                        topRight: Radius.circular(12))),
                child: const Padding(
                  padding: EdgeInsets.only(left: 40, top: 20),
                  child: Text(
                    "PROBLEMS",
                    style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.w500,
                        color: Color.fromARGB(255, 107, 114, 128)),
                  ),
                ),
              ),

              Column(
                  children: problems
                      .asMap()
                      .entries
                      .map(
                        (e) => Container(
                          width: double.maxFinite,
                          height: 60,
                          decoration: BoxDecoration(
                              border: Border.all(
                                  width: 1,
                                  color:
                                      const Color.fromARGB(255, 229, 231, 235)),
                              color: Colors.white),
                          child: Padding(
                            padding: const EdgeInsets.only(left: 40, right: 30),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                const Text(
                                  "1. LETTER",
                                  style: TextStyle(
                                      fontSize: 14,
                                      fontWeight: FontWeight.w500,
                                      color:
                                          Color.fromARGB(255, 107, 114, 128)),
                                ),
                                Row(
                                  children: [
                                    const Text(
                                      "Warning",
                                      style: TextStyle(
                                          fontWeight: FontWeight.w400,
                                          fontSize: 16,
                                          color: Color.fromARGB(
                                              255, 242, 119, 119)),
                                    ),
                                    const SizedBox(
                                      width: 20,
                                    ),
                                    GestureDetector(
                                        onTap: () {
                                          removeProblem(e.key);
                                        },
                                        child: const Icon(Icons.delete))
                                  ],
                                )
                              ],
                            ),
                          ),
                        ),
                      )
                      .toList()),


              const SizedBox(
                height: 20,
              ),
              Container(
                height: 40,
                width: 130,
                child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    // padding: EdgeInsets.symmetric(vertical: 12.0, horizontal: 24.0),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(6.0),
                      // side: BorderSide(color: Colors.blue), // Border color
                    ),
                    // elevation: 4.0, // Elevation
                    backgroundColor: const Color.fromARGB(
                        255, 38, 78, 202), // Background color
                  ),
                  onPressed: () {},
                  child: const Text(
                    "Finish",
                    style: TextStyle(
                        fontWeight: FontWeight.w400, color: Colors.white),
                  ),
                ),
              ),
            ]),
          ),
        ));
  }
}
