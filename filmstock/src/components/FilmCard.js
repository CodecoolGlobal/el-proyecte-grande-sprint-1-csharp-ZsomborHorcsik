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
        <Card>
            <CardImage
                src="https://image.tmdb.org/t/p/original/og6S0aTZU6YUJAbqxeKjCa3kY1E.jpg"
                alt="Card Image"
            />
            
            <CardBody>
                <H6 color="gray">movie Title</H6>
                <Paragraph>8.7</Paragraph>
                <Paragraph color="gray">
                    description
                </Paragraph>
            </CardBody>

            <CardFooter>
                <Button color="blueGray" size="lg" ripple="light">
                    More...
                </Button>
            </CardFooter>
        </Card>
    );
}


export default FilmCard;