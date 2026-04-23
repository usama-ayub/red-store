import 'dart:html';
import 'dart:js';

import 'package:flutter/material.dart';
import 'package:helloworld/screens/constants.dart';
import 'package:helloworld/screens/productdetail_screen.dart';
import 'package:helloworld/screens/productform_screen.dart';
import 'package:helloworld/screens/register_screen.dart';
import 'package:helloworld/services/api_service.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});
  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  bool isLoading = true;
  List<dynamic> product = [];

  @override
  void initState() {
    super.initState();
    getProduct();
  }

  Future<void> getProduct() async {
    final api = ApiService();

    final response = await api.get('/products', useToken: false);

    if (response.success) {
      print(response.data.length);
      print('failed fetch');
      setState(() {
        product = response.data;
      });
      // final token = response.data['token'];
    } else {
      print('failed api     ');
    }
    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    double topMargin = MediaQuery.of(context).padding.top;

    return isLoading
        ? const Center(child: CircularProgressIndicator())
        : Scaffold(
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
                padding:
                    EdgeInsets.symmetric(horizontal: 22, vertical: topMargin),
                child: Column(
                  children: [
                    SizedBox(
                      height: 30,
                    ),
                    Material(
                      elevation: 2,
                      borderRadius: BorderRadius.circular(10),
                      child: TextField(
                          decoration: InputDecoration(
                        fillColor: lightBlueColor,
                        filled: true,
                        hintText: "Search",
                        prefixIcon: Icon(Icons.search),
                        border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(10),
                            borderSide: BorderSide.none),
                      )),
                    ),
                    SizedBox(
                      height: 30,
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text("Categoris",
                            style: TextStyle(
                                color: blackColor,
                                fontSize: 16,
                                fontWeight: FontWeight.w400)),
                        InkWell(
                          onTap: () {},
                          child: Text("Show All",
                              style:
                                  TextStyle(color: primaryColor, fontSize: 13)),
                        )
                      ],
                    ),
                    SizedBox(
                        height: 90,
                        child: ListView.separated(
                            scrollDirection: Axis.horizontal,
                            itemCount: 5,
                            separatorBuilder: (context, index) =>
                                SizedBox(width: 10),
                            itemBuilder: (context, index) => Column(
                                  children: [
                                    Container(
                                      width: 60,
                                      height: 60,
                                      decoration: BoxDecoration(
                                          shape: BoxShape.circle,
                                          image: DecorationImage(
                                              image: AssetImage(
                                                  'assets/illustration.png'),
                                              fit: BoxFit.cover)),
                                    ),
                                    SizedBox(
                                      height: 5,
                                    ),
                                    Text('Pain Cake')
                                  ],
                                ))),
                    SizedBox(height: 10),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          children: [
                            Text("Home",
                                style: TextStyle(
                                    color: blackColor,
                                    fontSize: 17,
                                    fontWeight: FontWeight.w400)),
                            InkWell(
                              onTap: () {
                                Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                        builder: (context) =>
                                            const SellProductForm()));
                              },
                              child: Icon(
                                Icons.add_outlined,
                                size: 17,
                                color: primaryColor,
                              ),
                            )
                          ],
                        ),
                        InkWell(
                          onTap: () {},
                          child: Text("Show All",
                              style:
                                  TextStyle(color: primaryColor, fontSize: 13)),
                        )
                      ],
                    ),
                    Expanded(
                        child: ListView.separated(
                            itemCount: product.length,
                            itemBuilder: (context, index) {
                              final item = product[index];
                              return InkWell(
                                onTap: () {
                                  Navigator.push(
                                      context,
                                      MaterialPageRoute(
                                          builder: (context) =>
                                              const ProductDetailScreen(
                                                  productId: '34587')));
                                },
                                child: Material(
                                  elevation: 2,
                                  borderRadius: BorderRadius.circular(16),
                                  color: Colors.white,
                                  child: Container(
                                    height: 100,
                                    decoration: BoxDecoration(
                                        borderRadius:
                                            BorderRadius.circular(16)),
                                    child: Row(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        Container(
                                          width: 100,
                                          height: 100,
                                          clipBehavior: Clip.hardEdge,
                                          decoration: BoxDecoration(
                                            borderRadius:
                                                BorderRadius.circular(8),
                                          ),
                                          child: Image.network(
                                            item['image'],
                                            fit: BoxFit.contain,
                                          ),
                                        ),
                                        SizedBox(
                                          width: 10,
                                        ),
                                        Column(
                                          crossAxisAlignment:
                                              CrossAxisAlignment.start,
                                          children: [
                                            // Text('Restaurant 01'),
                                            Text(
                                              // item['title'] ?? 'No title',
                                              item['category'] ?? 'No title',
                                              overflow: TextOverflow.ellipsis,
                                            ),
                                            Row(
                                              children: [
                                                Icon(
                                                  Icons.star,
                                                  color: Colors.yellow,
                                                ),
                                                Text(
                                                    '${item['rating']['rate']}')
                                              ],
                                            ),
                                            SizedBox(height: 20),
                                            Row(
                                              children: [
                                                Icon(
                                                  Icons.timer,
                                                  color: Colors.grey,
                                                ),
                                                Text('20-25 mins  * 7 km')
                                              ],
                                            )
                                          ],
                                        ),
                                        Spacer(),
                                        Container(
                                          decoration: BoxDecoration(
                                              color: blackColor,
                                              borderRadius: BorderRadius.only(
                                                  bottomLeft:
                                                      Radius.circular(16),
                                                  topRight:
                                                      Radius.circular(16))),
                                          height: 30,
                                          width: 60,
                                          child: Center(
                                              child: Text(
                                            'New',
                                            style: TextStyle(
                                                color: whiteColor,
                                                fontSize: 13),
                                          )),
                                        )
                                      ],
                                    ),
                                  ),
                                ),
                              );
                            },
                            separatorBuilder: (context, index) => SizedBox(
                                  height: 10,
                                )))
                  ],
                ),
              )
            ],
          ));
  }
}
