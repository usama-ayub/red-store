import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:helloworld/providers/navigation_provider.dart';
import 'package:helloworld/screens/constants.dart';
import 'package:helloworld/screens/home_screen.dart';
import 'package:helloworld/screens/product_screen.dart';
import 'package:helloworld/screens/profile_screen.dart';
import 'package:helloworld/screens/shop_screen.dart';

class MainScreen extends StatelessWidget {
  const MainScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Custom Bottom Menu List for changes',
      theme: ThemeData(
        useMaterial3: false,
        scaffoldBackgroundColor:
            const Color(0xFFF3F4F6), // soft grey behind bar
        fontFamily: 'Roboto',
      ),
      home: const Home(),
    );
  }
}

class Home extends ConsumerWidget {
  const Home({super.key});

  final _pages = const [
    _DemoPage(title: 'Home', screen: HomeScreen()),
    _DemoPage(title: 'Product', screen: ProductScreen()),
    _DemoPage(title: 'Shop', screen: ShopScreen()),
    _DemoPage(title: 'Profile', screen: ProfileScreen()),
  ];

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final index = ref.watch(navigationProvider);
    return Scaffold(
      body: IndexedStack(index: index, children: _pages),
      bottomNavigationBar: CustomBottomBar(
        currentIndex: index,
        onTap: (i) => ref.read(navigationProvider.notifier).updateIndex(i),
      ),
    );
  }
}

class CustomBottomBar extends StatelessWidget {
  final int currentIndex;
  final ValueChanged<int> onTap;

  const CustomBottomBar({
    super.key,
    required this.currentIndex,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    const double barHeight = 68;

    return SafeArea(
      minimum: const EdgeInsets.fromLTRB(16, 8, 16, 16),
      child: Container(
        height: barHeight,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(22),
          boxShadow: [
            BoxShadow(
              blurRadius: 24,
              spreadRadius: 0,
              offset: const Offset(0, 10),
              color: Colors.black.withOpacity(0.08),
            ),
          ],
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: const [
            _BarItem(icon: Icons.home_rounded, itemIndex: 0),
            _BarItem(icon: Icons.shopping_bag_outlined, itemIndex: 1),
            _BarItem(icon: Icons.store, itemIndex: 2),
            _BarItem(icon: Icons.person_outline_rounded, itemIndex: 3),
          ].map((w) {
            return _BarItemWrapper(
              child: w,
              currentIndex: currentIndex,
              onTap: onTap,
            );
          }).toList(),
        ),
      ),
    );
  }
}

class _BarItemWrapper extends StatelessWidget {
  final _BarItem child;
  final int currentIndex;
  final ValueChanged<int> onTap;

  const _BarItemWrapper({
    required this.child,
    required this.currentIndex,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    final bool selected = child.itemIndex == currentIndex;

    return Expanded(
      child: Center(
        child: InkResponse(
          onTap: () => onTap(child.itemIndex),
          customBorder: const CircleBorder(),
          radius: 28,
          child: AnimatedContainer(
            duration: const Duration(milliseconds: 180),
            curve: Curves.easeOut,
            width: 42,
            height: 42,
            decoration: BoxDecoration(
              shape: BoxShape.circle,
              color: selected ? primaryColor : Colors.transparent,
            ),
            child: Icon(
              child.icon,
              size: 22,
              color: selected
                  ? Colors.white
                  : Colors.black.withOpacity(0.35), // light grey icons
            ),
          ),
        ),
      ),
    );
  }
}

class _BarItem {
  final IconData icon;
  final int itemIndex;
  const _BarItem({required this.icon, required this.itemIndex});
}

class _DemoPage extends StatelessWidget {
  final String title;
  final Widget? screen;
  const _DemoPage({required this.title, this.screen});

  @override
  Widget build(BuildContext context) {
    if (screen != null) {
      return screen!;
    }
    return Center(
      child: Text(
        title,
        style: const TextStyle(fontSize: 28, fontWeight: FontWeight.w600),
      ),
    );
  }
}
