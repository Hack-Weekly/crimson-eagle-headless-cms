import { Meta, StoryObj } from "@storybook/react";
import React from "react";

import Hamburger from "../components/ui/hamburgerMenu";

const meta: Meta<typeof Hamburger> = {
  title: "UI/HamburgerMenu",
  component: Hamburger,
};
export default meta;
type Story = StoryObj<typeof Hamburger>;

export const Default: Story = {
  args: {
    isOpen: false,
    onClick: () => {
      // Handle click event
    },
  },
};

export const Open: Story = {
  args: {
    isOpen: true,
    onClick: () => {
      // Handle click event
    },
  },
};
