import { cn } from "@/lib/utils";
import { Cross1Icon, HamburgerMenuIcon } from "@radix-ui/react-icons";
import React, { useState } from "react";

interface HamburgerProps {
  isOpen: boolean;
  onClick: () => void;
}

const Hamburger = ({ isOpen = false, onClick }: HamburgerProps) => {
  const [isMenuOpen, setIsMenuOpen] = useState<boolean>(isOpen);

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
    onClick();
  };

  return (
    <div className={"relative"}>
      <button
        className={
          "p-2 rounded-md border border-gray-300 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-offset-gray-100 focus:ring-indigo-500"
        }
        onClick={toggleMenu}
      >
        {isMenuOpen ? (
          <Cross1Icon className={"h-6 w-6"} />
        ) : (
          <HamburgerMenuIcon className={"h-6 w-6"} />
        )}
      </button>

      {isMenuOpen && (
        <div
          className={cn(
            "absolute z-10 right-0 mt-2 w-56 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 divide-y divide-gray-100 focus:outline-none",
            // mergedClassNames,
            isOpen ? "" : "hidden"
          )}
          role="menu"
          aria-orientation="vertical"
          aria-labelledby="options-menu"
        >
          {/* Menu items go here */}
        </div>
      )}
    </div>
  );
};

export default Hamburger;
