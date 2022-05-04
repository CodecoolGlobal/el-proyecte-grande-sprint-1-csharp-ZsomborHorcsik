import React from "react";
import Card from "@material-tailwind/react/Card";
import CardImage from "@material-tailwind/react/CardImage";
import CardBody from "@material-tailwind/react/CardBody";
import CardFooter from "@material-tailwind/react/CardFooter";
import H6 from "@material-tailwind/react/Heading6";
import Paragraph from "@material-tailwind/react/Paragraph";
import Button from "@material-tailwind/react/Button";

const FilmCard = () => {
    return (
        <div className="mx-2">
            <Card>
                <CardImage
                    src="https://image.tmdb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"
                    alt="Card Image"
                />

                <CardBody>
                    <H6 color="gray">Inception (2018)</H6>
                    <Paragraph>8.7</Paragraph>
                </CardBody>

                <CardFooter>
                    <Button color="blueGray" size="lg" ripple="light">
                        Read More
                    </Button>
                </CardFooter>
            </Card>
        </div>
        
    );
}

export default FilmCard;