"use client";
import { NavigationMenu } from "@radix-ui/react-navigation-menu";
import React from "react";
import Left from "./Left";
import Right from "./Right";

type NavbarProps = {};

const Navbar: React.FC<NavbarProps> = () => {
  return (
    <NavigationMenu className="flex items-center justify-between h-12 px-8 bg-secondary">
      <Left />
      <Right />
    </NavigationMenu>
  );
};
export default Navbar;
