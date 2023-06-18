"use client";

import {
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "@radix-ui/react-navigation-menu";
import Link from "next/link";
import React from "react";
import { navigationMenuTriggerStyle } from "../ui/navigation-menu";

type LeftProps = {};

const Left: React.FC<LeftProps> = () => {
  const listItems = [
    { label: "Manager", url: "/manager" },
    { label: "Builder", url: "/builder" },
    { label: "Media", url: "/medialib" },
    { label: "Settings", url: "/settings" },
  ];
  return (
    <NavigationMenuList className="flex gap-2">
      {listItems.map((item, i) => (
        <NavigationMenuItem key={i}>
          <Link href={item.url} legacyBehavior passHref>
            <NavigationMenuLink className={navigationMenuTriggerStyle()}>
              {item.label}
            </NavigationMenuLink>
          </Link>
        </NavigationMenuItem>
      ))}
    </NavigationMenuList>
  );
};
export default Left;
