import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import type { Meta, StoryObj } from "@storybook/react";

const meta: Meta<typeof Input> = {
  title: "UI/Input",
  component: Input,
};
export default meta;
type Story = StoryObj<typeof Input>;

export const Text: Story = {
  args: {
    type: "text",
    placeholder: "text",
  },
  render: (args) => <Input {...args} />,
};
export const Password: Story = {
  args: {
    type: "password",
    placeholder: "password",
  },
  render: (args) => <Input {...args} />,
};
