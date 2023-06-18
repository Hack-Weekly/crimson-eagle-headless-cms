"use client";

import { ThemeTypes, themeContext } from "@/context/themeContext";
import { Avatar, AvatarFallback, AvatarImage } from "@radix-ui/react-avatar";
import { Label } from "@radix-ui/react-label";
import {
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "@radix-ui/react-navigation-menu";
import React, { useContext } from "react";
import { Switch } from "../ui/switch";

type RightProps = {};

const Right: React.FC<RightProps> = () => {
  const context = useContext(themeContext);
  return (
    <NavigationMenuList className="flex  items-center justify-center gap-4">
      <NavigationMenuItem className="flex items-center gap-1">
        <Switch
          onCheckedChange={() => {
            context?.dispatch({ type: ThemeTypes.ToggleTheme });
          }}
          checked={context?.theme === "light" ? true : false}
          id="dark-mode"
        />
        <Label htmlFor="dark-mode">Dark mood</Label>
      </NavigationMenuItem>
      <NavigationMenuItem>
        <Avatar className="flex items-center justify-center overflow-hidden w-10 h-10 rounded-full">
          <AvatarImage
            className="w-full h-full object-contain"
            src="https://github.com/shadcn.png"
            alt="avatar"
          />
          <AvatarFallback>CN</AvatarFallback>
        </Avatar>
      </NavigationMenuItem>
    </NavigationMenuList>
  );
};
export default Right;
