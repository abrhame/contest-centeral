import { Transition } from "@headlessui/react";
import React, { useState } from "react";

type Props = {};

const Notification = (props: Props) => {
  const [isShowing, setIsShowing] = useState(false);
  return (
    <div>
      <button onClick={() => setIsShowing((isShowing) => !isShowing)}>
        Toggle
      </button>
      <Transition
        show={isShowing}
        enter="transition-opacity duration-75"
        enterFrom="opacity-0"
        enterTo="opacity-100"
        leave="transition-opacity duration-150"
        leaveFrom="opacity-100"
        leaveTo="opacity-0"
      >
        I will fade in and out
      </Transition>
    </div>
  );
};

export default Notification;
