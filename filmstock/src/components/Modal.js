import React from "react";
import { useState } from "react";
import Modal from "@material-tailwind/react/Modal";
import ModalHeader from "@material-tailwind/react/ModalHeader";
import ModalBody from "@material-tailwind/react/ModalBody";
import ModalFooter from "@material-tailwind/react/ModalFooter";
import Button from "@material-tailwind/react/Button";

const MovieModal = ()=> {
    const [showModal, setShowModal] = useState(false);

    return (
        <>
            <Button
                color="blueGray"
                type="button"
                onClick={(e) => setShowModal(true)}
                ripple="light"
            >
                Go to discussion
            </Button>

            <Modal size="lg" active={showModal} toggler={() => setShowModal(false)}>
                <ModalHeader toggler={() => setShowModal(false)}>
                    Movie title
                </ModalHeader>
                <ModalBody>
                    <p className="text-base leading-relaxed text-gray-600 font-normal">
                        I always felt like I could do anything. That’s the main thing people
                        are controlled by! Thoughts- their perception of themselves! They're
                        slowed down by their perception of themselves. If you're taught you
                        can’t do anything, you won’t do anything. I was taught I could do
                        everything.
                    </p>
                </ModalBody>
                <ModalFooter>
                    <Button 
                        color="red"
                        buttonType="link"
                        onClick={(e) => setShowModal(false)}
                        ripple="dark"
                    >
                        Close
                    </Button>

                    <Button
                        color="green"
                        onClick={(e) => setShowModal(false)}
                        ripple="light"
                    >
                        Jump to page
                    </Button>
                </ModalFooter>
            </Modal>
        </>
    );
}

export default MovieModal;