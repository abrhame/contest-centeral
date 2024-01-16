import 'package:flutter/material.dart';

class AddContest extends StatefulWidget {
  @override
  _AddContestState createState() => _AddContestState();
}

class _AddContestState extends State<AddContest> {
  late int showingTooltip;
  List<Map<String, String>> problems = [];
  final problemSetController = TextEditingController();
  @override
  void initState() {
    showingTooltip = -1;
    super.initState();
  }

  void addProblem(String name) {
    setState(() {
      problems.add({'name': name});
    });
  }

  void removeProblem(int indx) {
    setState(() {
      problems.removeAt(indx);
    });
  }

  String _selectedGroup = "select";
  List<String> _selectedGroups = [];

  String _selectedCountry = "select";
  List<String> _selectedCountries = [];

  String _selectedUniversity = "select";
  List<String> _selectedUniversities = [];

  Widget buildDropdown(
    String value,
    List<String> items,
    String hintText,
    Function(String?) onChanged,
  ) {
    return Container(
      width: MediaQuery.of(context).size.width * 0.9,
      height: 50,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(5),
        color: Colors.white,
      ),
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 15),
        child: DropdownButton(
          value: value,
          icon: const Padding(
            padding: EdgeInsets.only(left: 190.0),
            child: Icon(Icons.expand_more),
          ),
          iconSize: 24,
          elevation: 16,
          underline: Container(
            height: 2,
          ),
          items: [
            const DropdownMenuItem(
              value: "select",
              child: Text(
                "Select",
                style: TextStyle(
                  color: Color.fromARGB(255, 147, 150, 153),
                ),
              ),
            ),
            for (String item in items)
              DropdownMenuItem(
                value: item,
                child: Text(
                  item,
                  style: const TextStyle(
                    color: Color.fromARGB(255, 147, 150, 153),
                  ),
                ),
              ),
          ],
          onChanged: (String? newValue) {
            onChanged(newValue);
          },
        ),
      ),
    );
  }

  Widget buildChipList(List<String> items, Function(String) onDeleted) {
    return SingleChildScrollView(
      child: Wrap(
        spacing: 8.0,
        direction: Axis.horizontal,
        children: items.map((item) {
          return Chip(
            label: Text(item),
            onDeleted: () {
              onDeleted(item);
            },
          );
        }).toList(),
      ),
    );
  }

  bool isLoading = false;
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
              backgroundImage: AssetImage('assets/images/no_profile.png'),
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
              Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text(
                    "Group",
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                      color: Color.fromARGB(255, 107, 114, 128),
                    ),
                  ),
                  const SizedBox(height: 10),
                  buildDropdown(
                    _selectedGroup,
                    ["Group 45", "Group 46"],
                    "Select Group",
                    (String? newValue) {
                      setState(() {
                        _selectedGroup = newValue!;
                        if (_selectedGroup != "select" &&
                            !_selectedGroups.contains(newValue)) {
                          _selectedGroups.add(newValue);
                        }
                      });
                    },
                  ),
                  const SizedBox(height: 10),
                  const Text(
                    "Country",
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                      color: Color.fromARGB(255, 107, 114, 128),
                    ),
                  ),
                  const SizedBox(height: 10),
                  buildDropdown(
                    _selectedCountry,
                    ["Ethiopia", "Ghana"],
                    "Select Country",
                    (String? newValue) {
                      setState(() {
                        _selectedCountry = newValue!;
                        if (_selectedCountry != "select" &&
                            !_selectedCountries.contains(newValue)) {
                          _selectedCountries.add(newValue);
                        }
                      });
                    },
                  ),
                  const SizedBox(height: 10),
                  const Text(
                    "University",
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                      color: Color.fromARGB(255, 107, 114, 128),
                    ),
                  ),
                  const SizedBox(height: 10),
                  buildChipList(_selectedCountries, (item) {
                    setState(() {
                      _selectedCountries.remove(item);
                      _selectedCountry = "select";
                    });
                  }),
                  const SizedBox(height: 10),
                  buildDropdown(
                    _selectedUniversity,
                    ["AASTU", "AAiT"],
                    "Select University",
                    (String? newValue) {
                      setState(() {
                        _selectedUniversity = newValue!;
                        if (_selectedUniversity != "select" &&
                            !_selectedUniversities.contains(newValue)) {
                          _selectedUniversities.add(newValue);
                        }
                      });
                    },
                  ),
                  buildChipList(_selectedUniversities, (item) {
                    setState(() {
                      _selectedUniversities.remove(item);
                      _selectedUniversity = "select";
                    });
                  }),
                  const SizedBox(height: 10),
                ],
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
                      hintText: "Enter Contest Name",
                      hintStyle: TextStyle(
                          color: Color.fromARGB(255, 147, 150, 153),
                          fontWeight: FontWeight.normal),
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
                      hintText: "https://codeforces.com/gym/104686",
                      hintStyle: TextStyle(
                          color: Color.fromARGB(255, 147, 150, 153),
                          fontWeight: FontWeight.normal),
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
                child: TextField(
                  controller: problemSetController,
                  cursorColor: const Color.fromARGB(255, 102, 102, 102),
                  decoration: const InputDecoration(
                      hintText: "Enter Problem Name",
                      hintStyle: TextStyle(
                          color: Color.fromARGB(255, 147, 150, 153),
                          fontWeight: FontWeight.normal),
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
                      hintText: "https://codeforces.com/problemset/",
                      hintStyle: TextStyle(
                          color: Color.fromARGB(255, 147, 150, 153),
                          fontWeight: FontWeight.normal),
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
                    addProblem(problemSetController.text);
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
                                Text(
                                  e.value['name']!,
                                  style: const TextStyle(
                                      fontSize: 14,
                                      fontWeight: FontWeight.w500,
                                      color:
                                          Color.fromARGB(255, 107, 114, 128)),
                                ),
                                Row(
                                  children: [
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
              Center(
                child: Container(
                  height: 40,
                  width: double.maxFinite,
                  child: ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(6.0),
                      ),
                      backgroundColor: const Color.fromARGB(255, 38, 78, 202),
                    ),
                    onPressed: isLoading ? null : _onButtonPressed,
                    child: isLoading
                        ? const CircularProgressIndicator(
                            valueColor:
                                AlwaysStoppedAnimation<Color>(Colors.white),
                          )
                        : const Text(
                            "Create Contest",
                            style: TextStyle(
                              fontWeight: FontWeight.w400,
                              color: Colors.white,
                            ),
                          ),
                  ),
                ),
              )
            ]),
          ),
        ));
  }

  void _onButtonPressed() {
    setState(() {
      isLoading = true;
    });

    // Simulate a delay of 3 seconds
    Future.delayed(const Duration(seconds: 3), () {
      setState(() {
        isLoading = false;
      });

      // Show Snackbar
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          backgroundColor: Color.fromARGB(255, 127, 36, 29),
          content: Text('Question Already Exist'),
          duration: Duration(seconds: 3),
        ),
      );
    });
  }
}
