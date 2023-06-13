"use client";

import {
  Link,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "@radix-ui/react-navigation-menu";
import React from "react";
import { navigationMenuTriggerStyle } from "../ui/navigation-menu";

type LeftProps = {};
const listItems = [
  { label: "Manager", url: "/manager" },
  { label: "Builder", url: "/builder" },
  { label: "Media", url: "/media" },
  { label: "Settings", url: "/settings" },
];
const Left: React.FC<LeftProps> = () => {
  return (
    <NavigationMenuList className="flex gap-2">
      {listItems.map((item, i) => (
        <NavigationMenuItem key={i}>
          <Link href={item.url}>
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
